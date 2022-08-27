using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class LoginForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = aserzamzam12; Integrated Security = True");
         //SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked == false)
                txtPass.UseSystemPasswordChar = true;
            else
                txtPass.UseSystemPasswordChar = false;
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPass.Clear();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد الخروج من البرنامج ؟", "تاكيد ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                
                cm = new SqlCommand("SELECT * FROM tbUser WHERE username=@username AND password=@password", con);
                cm.Parameters.AddWithValue("@username", txtName.Text);
                cm.Parameters.AddWithValue("@password", txtPass.Text);
                con.Open();
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows )
                {
                    MainForm productModule = new MainForm();
                    MessageBox.Show("مرحبا " + dr["fullname"].ToString() + "  ", "تم التسجيل بنجاح ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = dr["username"].ToString();
                    if (textBox1.Text == "admin")
                    {
                        productModule.customerButton3.Enabled = true;
                        productModule.customerButton4.Enabled = true;
                        productModule.customerButton2.Enabled = true;
                        productModule.customerButton1.Enabled = true;
                        productModule.customerButton5.Enabled = true;
                        productModule.btnOrder.Enabled = true;
                        productModule.btnUser.Enabled = true;
                        productModule.customerButton6.Enabled = true;
                        this.Hide();
                        productModule.ShowDialog();
                    }
                    else
                    {
                        productModule.customerButton3.Enabled = true;
                        productModule.customerButton4.Enabled = true;
                        productModule.customerButton2.Enabled = true;
                        productModule.customerButton1.Enabled = true;
                        productModule.customerButton5.Enabled = true;
                        productModule.btnOrder.Enabled = true;
                        productModule.btnUser.Enabled = true;
                        productModule.customerButton6.Enabled = true;
                       // productModule.customerButton3.Enabled = false;
                       // productModule.customerButton4.Enabled = false;
                       // productModule.customerButton2.Enabled = false;
                       // productModule.customerButton1.Enabled = false;
                       // productModule.customerButton5.Enabled = false;
                       // productModule.btnOrder.Enabled = false;
                       // productModule.btnUser.Enabled = false;
                       // productModule.customerButton6.Enabled = false;
                        this.Hide();
                        productModule.ShowDialog();

                    }
                    
                    
                }
                else
                {
                    MessageBox.Show("!خطأ فى كلمه السر او اسم المستخدم", " فشل التسجيل ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
