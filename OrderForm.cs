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
    public partial class OrderForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = aserzamzam12; Integrated Security = True");
        //SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public OrderForm()
        {
            InitializeComponent();
            LoadOrder();
        }

        public void LoadOrder()
        {

            double total = 0;
            double tota2 = 0;
            double total3 = 0;
            double total4 = 0;
            //double total5 = 0;



            int i = 0;
            dgvOrder.Rows.Clear();
            cm = new SqlCommand("SELECT ordid,KID, date, Kname, Knum, Kmark, date1, date2, priceG,FpriceG,SpriceG,kphone,priceK,tak FROM Korder  WHERE date between @fd and @sd ", con);
            cm.Parameters.AddWithValue("@fd", dateTimePicker1.Value.Date);
            cm.Parameters.AddWithValue("@sd", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvOrder.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), Convert.ToDateTime(dr[2].ToString()).ToString("dd/MM/yyyy"), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToDateTime(dr[6].ToString()).ToString("dd/MM/yyyy"), Convert.ToDateTime(dr[7].ToString()).ToString("dd/MM/yyyy"), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString(), dr[12].ToString(), dr[13].ToString());
                total += Convert.ToInt32(dr[8].ToString());
                tota2 += Convert.ToInt32(dr[4].ToString());
                total3 += Convert.ToInt32(dr[9].ToString());
                total4 += Convert.ToInt32(dr[10].ToString());
                //double total3 += Convert.ToInt32(dr[8].ToString());
                //double total4 += Convert.ToInt32(dr[6].ToString());
                //total5 = total3 - total4;

            }
            dr.Close();
            con.Close();
            //double a = double.Parse(label7.Text);
            //double b = double.Parse(label9.Text);
            //double c = a - b;
            label8.Text = i.ToString();
            label7.Text = total.ToString();
            label9.Text = tota2.ToString();
            label24.Text = total3.ToString();
            label25.Text = total4.ToString();
            //label10.Text = total5.ToString();


            double total6 = 0;
            int n = 0;
            dataGridView2.Rows.Clear();
            cm = new SqlCommand("SELECT date,price,dec FROM nas where date between @fdn and @sdn", con);
            cm.Parameters.AddWithValue("@fdn", dateTimePicker1.Value.Date);
            cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                n++;
                dataGridView2.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                total6 += Convert.ToInt32(dr[1].ToString());
            }
            dr.Close();
            con.Close();
            label4.Text = total6.ToString();
            double total5 = total - total6;
            label10.Text = total5.ToString();



        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Korder moduleForm = new Korder();
            moduleForm.btnInsert.Enabled = true;
            moduleForm.btnUpdate.Enabled = false;
            moduleForm.Kd11.Visible = false;
            moduleForm.Kd22.Visible = false;
            moduleForm.kd1.Visible = true;
            moduleForm.kd2.Visible = true;
            moduleForm.ShowDialog();
            LoadOrder();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOrder.Columns[e.ColumnIndex].Name;
            
            if (colName == "Delete")
            {
                if (MessageBox.Show("هل انت متاكد من حذف هذا الاوردر؟", "جاري الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbOrder WHERE orderid LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("!تم الحذف بنجاح");

                    cm = new SqlCommand("UPDATE tbProduct SET pqty=(pqty+@pqty) WHERE pid LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString() + "' ", con);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(dgvOrder.Rows[e.RowIndex].Cells[5].Value.ToString()));

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                }
            }
            LoadOrder();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double total = 0;
            double tota2 = 0;
            double total3 = 0;
            double total4 = 0;
            //double total5 = 0;



            int i = 0;
            dgvOrder.Rows.Clear();
            cm = new SqlCommand("SELECT ordid,KID, date, Kname, Knum, Kmark, date1, date2,priceG,FpriceG,SpriceG,kphone,priceK,tak FROM Korder  WHERE date between @fd and @sd ", con);
            cm.Parameters.AddWithValue("@fd", dateTimePicker1.Value.Date);
            cm.Parameters.AddWithValue("@sd", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvOrder.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), Convert.ToDateTime(dr[2].ToString()).ToString("dd/MM/yyyy"), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToDateTime(dr[6].ToString()).ToString("dd/MM/yyyy"), Convert.ToDateTime(dr[7].ToString()).ToString("dd/MM/yyyy"), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString(), dr[12].ToString(), dr[13].ToString());
                total += Convert.ToInt32(dr[8].ToString());
                tota2 += Convert.ToInt32(dr[4].ToString());
                total3 += Convert.ToInt32(dr[9].ToString());
                total4 += Convert.ToInt32(dr[10].ToString());
                //double total3 += Convert.ToInt32(dr[8].ToString());
                //double total4 += Convert.ToInt32(dr[6].ToString());
                //total5 = total3 - total4;

            }
            dr.Close();
            con.Close();
            //double a = double.Parse(label7.Text);
            //double b = double.Parse(label9.Text);
            //double c = a - b;
            label8.Text = i.ToString();
            label7.Text = total.ToString();
            label9.Text = tota2.ToString();
            label24.Text = total3.ToString();
            label25.Text = total4.ToString();
            //label10.Text = total5.ToString();


            double total6 = 0;
            int n = 0;
            dataGridView2.Rows.Clear();
            cm = new SqlCommand("SELECT date,price,dec FROM nas where date between @fdn and @sdn", con);
            cm.Parameters.AddWithValue("@fdn", dateTimePicker1.Value.Date);
            cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                n++;
                dataGridView2.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                total6 += Convert.ToInt32(dr[1].ToString());
            }
            dr.Close();
            con.Close();
            label4.Text = total6.ToString();
            double total5 = total - total6;
            label10.Text = total5.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double total = 0;
            double tota2 = 0;
            double total3 = 0;
            double total4 = 0;
            //double total5 = 0;



            int i = 0;
            dgvOrder.Rows.Clear();
            cm = new SqlCommand("SELECT ordid,KID, date, Kname, Knum, Kmark, date1, date2,priceG,FpriceG,SpriceG,kphone,priceK,tak FROM Korder ", con);
            //cm.Parameters.AddWithValue("@fd", dateTimePicker1.Value.Date);
            //cm.Parameters.AddWithValue("@sd", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvOrder.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), Convert.ToDateTime(dr[2].ToString()).ToString("dd/MM/yyyy"), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToDateTime(dr[6].ToString()).ToString("dd/MM/yyyy"), Convert.ToDateTime(dr[7].ToString()).ToString("dd/MM/yyyy"), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString(), dr[12].ToString(), dr[13].ToString());
                total += Convert.ToInt32(dr[8].ToString());
                tota2 += Convert.ToInt32(dr[4].ToString());
                total3 += Convert.ToInt32(dr[9].ToString());
                total4 += Convert.ToInt32(dr[10].ToString());
                //double total3 += Convert.ToInt32(dr[8].ToString());
                //double total4 += Convert.ToInt32(dr[6].ToString());
                //total5 = total3 - total4;

            }
            dr.Close();
            con.Close();
            //double a = double.Parse(label7.Text);
            //double b = double.Parse(label9.Text);
            //double c = a - b;
            label8.Text = i.ToString();
            label7.Text = total.ToString();
            label9.Text = tota2.ToString();
            label24.Text = total3.ToString();
            label25.Text = total4.ToString();
            //label10.Text = total5.ToString();


            double total6 = 0;
            int n = 0;
            dataGridView2.Rows.Clear();
            cm = new SqlCommand("SELECT date,price,dec FROM nas", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                n++;
                dataGridView2.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                total6+= Convert.ToInt32(dr[1].ToString());
            }
            dr.Close();
            con.Close();
            label4.Text = total6.ToString();
            double total5 = total - total6;
            label10.Text = total5.ToString();
            dataGridView2.Rows.Clear();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOrder.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                Korder productModule = new Korder();
                productModule.lblPid.Text = dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString();
                productModule.ID.Text = dgvOrder.Rows[e.RowIndex].Cells[2].Value.ToString();
                productModule.textname.Text = dgvOrder.Rows[e.RowIndex].Cells[4].Value.ToString();
                productModule.Knum.Text = dgvOrder.Rows[e.RowIndex].Cells[5].Value.ToString();
                productModule.Kmark.Text = dgvOrder.Rows[e.RowIndex].Cells[6].Value.ToString();
                productModule.Kd11.Text = dgvOrder.Rows[e.RowIndex].Cells[7].Value.ToString();
                productModule.Kd22.Text = dgvOrder.Rows[e.RowIndex].Cells[8].Value.ToString();
                productModule.PG.Text = dgvOrder.Rows[e.RowIndex].Cells[9].Value.ToString();
                productModule.PK.Text = dgvOrder.Rows[e.RowIndex].Cells[13].Value.ToString();
                productModule.FPG.Text = dgvOrder.Rows[e.RowIndex].Cells[10].Value.ToString();
                //productModule.FPK.Text = dgvOrder.Rows[e.RowIndex].Cells[12].Value.ToString();
                productModule.NPG.Text = dgvOrder.Rows[e.RowIndex].Cells[11].Value.ToString();
                //productModule.NPK.Text = dgvOrder.Rows[e.RowIndex].Cells[14].Value.ToString();
                productModule.txtPhone.Text = dgvOrder.Rows[e.RowIndex].Cells[12].Value.ToString();
                productModule.btnInsert.Enabled = false;
                productModule.button1.Enabled = false;
                productModule.btnUpdate.Enabled = true;
                productModule.Kd11.Visible = true;
                productModule.Kd22.Visible = true;
                productModule.kd1.Visible = true;
                productModule.kd2.Visible = true;
                productModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("هل انت متاكد من حذف هذا الاوردر؟", "جاري الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM Korder WHERE ordid LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("!تم الحذف بنجاح");

                    //cm = new SqlCommand("UPDATE tbProduct SET pqty=(pqty+@pqty) WHERE pid LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString() + "' ", con);
                    //cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(dgvOrder.Rows[e.RowIndex].Cells[5].Value.ToString()));

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                }
            }
            LoadOrder();
        }
    }
}
