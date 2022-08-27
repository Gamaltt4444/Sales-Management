using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Threading;
using System.IO;
using System.Data.SqlClient;

namespace InventoryManagementSystem
{
    public partial class btuo : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = aserzamzam12; Integrated Security = True");
        SqlCommand cmd;
        public btuo()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void btnRestore_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Backup Files (*.Bak) |*.bak";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cmd = new SqlCommand("USE master; Restore database aserzamzam12 from disk = '" + openFileDialog1.FileName + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("! تم إسترداد النسخه الإحتياطية بنجاح ");

            }




            //DB.DBGeneral obj = new DB.DBGeneral();
            //My_Classes.DB_General obj = new My_Classes.DB_General();
            //obj.General_Query("Restore database aserzamzam12 from disk = '" + textBox2.Text + "'");

        }





        delegate void SetMessageCallback(string text);

        private void btnBackupDB_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Backup Files (*.Bak) |*.bak";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cmd = new SqlCommand("backup database aserzamzam12 to disk = '" + saveFileDialog1.FileName + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("! تم النسخ الإحتياطي بنجاح ");

            }
            // DB.DBGeneral obj = new DB.DBGeneral();
            //My_Classes.DB_General obj = new My_Classes.DB_General();
            // obj.General_Query("backup database aserzamzam12 to disk = '" + textBox1.Text + "'");
            MessageBox.Show("! تم النسخ بنجاح ");
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.Filter = "Backup files (*.bak)|*.bak";
            saveFileDialog1.ShowDialog();
            textBox1.Text = saveFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //openFileDialog1.AddExtension = true;
            openFileDialog1.Filter = "Backup Files (*.bak)|*.bak";
            openFileDialog1.ShowDialog();
            textBox2.Text = openFileDialog1.FileName;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
                BrowseBackupBtn.Enabled = true;
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {


            con.Open();
            String database = con.Database.ToString();
            try
            {
                if (textBox1.Text == string.Empty)
                {
                    //  s.Speak("please enter the valid backup file location");
                    MessageBox.Show("من فصلك اختار مكان حفظ النسخة الاحتياطية");
                }
                else
                {

                    string q = "BACKUP DATABASE [" + database + "] TO DISK='" + textBox1.Text + "\\" + "Database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";

                    SqlCommand scmd = new SqlCommand(q, con);
                    scmd.ExecuteNonQuery();
                    // s.Speak("Backup taken successfully");
                    MessageBox.Show("تم اخذ نسخة احتياطية من البيانات بنجاح", "جاري النسخ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button3.Enabled = false;

                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }


        

        private void RestoreBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "SQL SERVER database backup files|*.bak";
            ofd.Title = "Database Restore";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = ofd.FileName;
                RestoreBtn.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            String database = con.Database.ToString();
            try
            {
                if (textBox2.Text == string.Empty)
                {
                    //  s.Speak("please enter the valid backup file location");
                    MessageBox.Show("من فصلك اختار مكان النسخة الاحتياطية المحفوظة");
                }
                else
                {
                    string sql1 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    cmd1.ExecuteNonQuery();

                    string sql2 = string.Format("USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + textBox2.Text + "' WITH REPLACE;");
                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    cmd2.ExecuteNonQuery();

                    string sql3 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
                    SqlCommand cmd3 = new SqlCommand(sql3, con);
                    cmd3.ExecuteNonQuery();
                    // s.Speak("Database Restored successfully");
                    MessageBox.Show("تم استرجاع النسخة بنجاح", "جاري اتسرجاع النسخة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button4.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
