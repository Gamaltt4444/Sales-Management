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
    public partial class reportdate : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = aserzamzam12; Integrated Security = True");
        //SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public reportdate()
        {
            InitializeComponent();
            LoadOrder();
        }
        public void LoadOrder()
        {
              double total = 0;
        int i = 0;
        double total1 = 0;
        double total2 = 0;
        double total3 = 0;
        double total4 = 0;
        //double total3 = 0;
        int n = 0;
        dataGridView2.Rows.Clear();
            cm = new SqlCommand("SELECT date,price,dec FROM nas where date between @fdn and @sdn", con);
        cm.Parameters.AddWithValue("@fdn", dateTimePicker1.Value.Date);
            cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView2.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                total += Convert.ToInt32(dr[1].ToString());
            }
    dr.Close();
            con.Close();
            label22.Text = total.ToString();

            dataGridView1.Rows.Clear();
            cm = new SqlCommand("SELECT ordid,KID, date, Kname, Knum, Kmark, date1, date2, priceG,FpriceG,SpriceG,kphone,priceK,tak FROM Korder  WHERE date between @fd and @sd ", con);
    cm.Parameters.AddWithValue("@fd", dateTimePicker1.Value.Date);
            cm.Parameters.AddWithValue("@sd", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                n++;
                dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), Convert.ToDateTime(dr[2].ToString()).ToString("dd/MM/yyyy"), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToDateTime(dr[6].ToString()).ToString("dd/MM/yyyy"), Convert.ToDateTime(dr[7].ToString()).ToString("dd/MM/yyyy"), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString(), dr[12].ToString(), dr[13].ToString());
                total1 += Convert.ToInt32(dr[8].ToString());
                total2 += Convert.ToInt32(dr[4].ToString());
                total3 += Convert.ToInt32(dr[9].ToString());
                total4 += Convert.ToInt32(dr[10].ToString());
                //total3 += Convert.ToInt32(dr[6].ToString());

            }
                                dr.Close();
                         con.Close();
                       label21.Text = n.ToString();
                    label23.Text = total1.ToString();
                     label29.Text = total1.ToString();
                  label15.Text = total2.ToString();
                      double total5 = total1 - total;
                 label11.Text = total5.ToString();
                  label32.Text = total3.ToString();
                 label34.Text = total4.ToString();
                 double tot = total4 - total3;
                 label41.Text = tot.ToString();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            double total = 0;
            int i = 0;
            double total1 = 0;
            double total2 = 0;
            double total3 = 0;
            double total4 = 0;
            //double total3 = 0;
            int n = 0;
            dataGridView2.Rows.Clear();
            cm = new SqlCommand("SELECT date,price,dec FROM nas", con);
            //cm.Parameters.AddWithValue("@fdn", dateTimePicker1.Value.Date);
            //cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView2.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                total += Convert.ToInt32(dr[1].ToString());
            }
            dr.Close();
            con.Close();
            label22.Text = total.ToString();


            dataGridView1.Rows.Clear();
            cm = new SqlCommand("SELECT ordid,KID, date, Kname, Knum, Kmark, date1, date2, priceG,FpriceG,SpriceG,kphone,priceK,tak FROM Korder ", con);
            //cm.Parameters.AddWithValue("@fd", dateTimePicker1.Value.Date);
            //cm.Parameters.AddWithValue("@sd", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                n++;
                dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), Convert.ToDateTime(dr[2].ToString()).ToString("dd/MM/yyyy"), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToDateTime(dr[6].ToString()).ToString("dd/MM/yyyy"), Convert.ToDateTime(dr[7].ToString()).ToString("dd/MM/yyyy"), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString(), dr[12].ToString(), dr[13].ToString());
                total1 += Convert.ToInt32(dr[8].ToString());
                total2 += Convert.ToInt32(dr[4].ToString());
                total3 += Convert.ToInt32(dr[9].ToString());
                total4 += Convert.ToInt32(dr[10].ToString());

                //total3 += Convert.ToInt32(dr[6].ToString());
            }
            dr.Close();
            con.Close();
            label21.Text = n.ToString();
            label23.Text = total1.ToString();
            label29.Text = total1.ToString();
            label15.Text = total2.ToString();
            double total5 = total1 - total;
            label11.Text = total5.ToString();
            label32.Text = total3.ToString();
            label34.Text = total4.ToString();
            double tot = total4 - total3;
            label41.Text = tot.ToString();


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            double total = 0;
            int i = 0;
            double total1 = 0;
            double total2 = 0;
            double total3 = 0;
            double total4 = 0;
            //double total3 = 0;
            int n = 0;
            dataGridView2.Rows.Clear();
            cm = new SqlCommand("SELECT date,price,dec FROM nas where date between @fdn and @sdn", con);
            cm.Parameters.AddWithValue("@fdn", dateTimePicker1.Value.Date);
            cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView2.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                total += Convert.ToInt32(dr[1].ToString());
            }
            dr.Close();
            con.Close();
            label22.Text = total.ToString();

            dataGridView1.Rows.Clear();
            cm = new SqlCommand("SELECT ordid,KID, date, Kname, Knum, Kmark, date1, date2, priceG,FpriceG,SpriceG,kphone,priceK,tak FROM Korder  WHERE date between @fd and @sd ", con);
            cm.Parameters.AddWithValue("@fd", dateTimePicker1.Value.Date);
            cm.Parameters.AddWithValue("@sd", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                n++;
                dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), Convert.ToDateTime(dr[2].ToString()).ToString("dd/MM/yyyy"), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToDateTime(dr[6].ToString()).ToString("dd/MM/yyyy"), Convert.ToDateTime(dr[7].ToString()).ToString("dd/MM/yyyy"), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString(), dr[12].ToString(), dr[13].ToString());
                total1 += Convert.ToInt32(dr[8].ToString());
                total2 += Convert.ToInt32(dr[4].ToString());
                total3 += Convert.ToInt32(dr[9].ToString());
                total4 += Convert.ToInt32(dr[10].ToString());
                //total3 += Convert.ToInt32(dr[6].ToString());

            }
            dr.Close();
            con.Close();
            label21.Text = n.ToString();
            label23.Text = total1.ToString();
            label29.Text = total1.ToString();
            label15.Text = total2.ToString();
            double total5 = total1 - total;
            label11.Text = total5.ToString();
            label32.Text = total3.ToString();
            label34.Text = total4.ToString();
            double tot = total4 - total3;
            label41.Text = tot.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //double total = 0;
            //int i = 0;
            double total1 = 0;
            double total2 = 0;
            double total3 = 0;
            double total4 = 0;
            int n = 0;
            dataGridView1.Rows.Clear();
            cm = new SqlCommand("SELECT ordid,KID, date, Kname, Knum, Kmark, date1, date2, priceG,FpriceG,SpriceG,kphone,priceK,tak FROM Korder WHERE convert(varchar,ordid)+convert(varchar,KID)+convert(varchar,date)+ Kname+convert(varchar,Knum)+Kmark+convert(varchar,priceG)+convert(varchar,priceK)+convert(varchar,FpriceG)+convert(varchar,SpriceG)+convert(varchar,kphone) LIKE '%" + textBox1.Text + "%'", con);
            //cm.Parameters.AddWithValue("@fd", textBox1.Text);
            //cm.Parameters.AddWithValue("@sd", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                n++;
                dataGridView1.Rows.Add(n, dr[0].ToString(), dr[1].ToString(), Convert.ToDateTime(dr[2].ToString()).ToString("dd/MM/yyyy"), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToDateTime(dr[6].ToString()).ToString("dd/MM/yyyy"), Convert.ToDateTime(dr[7].ToString()).ToString("dd/MM/yyyy"), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString(), dr[12].ToString(),dr[13].ToString());
                total1 += Convert.ToInt32(dr[8].ToString());
                total2 += Convert.ToInt32(dr[4].ToString());
                total3 += Convert.ToInt32(dr[9].ToString());
                total4 += Convert.ToInt32(dr[10].ToString());
                //total3 += Convert.ToInt32(dr[6].ToString());

            }
            dr.Close();
            con.Close();
            label21.Text = n.ToString();
            label23.Text = total1.ToString();
            label29.Text = total1.ToString();
            label15.Text = total2.ToString();
            //double total5 = total1 - total;
            label11.Text = total1.ToString();
            label32.Text = total3.ToString();
            label34.Text = total4.ToString();
            double tot = total4 - total3;
            label41.Text = tot.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
               
                Korder productModule = new Korder();
                productModule.lblPid.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                productModule.ID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                productModule.textname.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                productModule.Knum.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                productModule.Kmark.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                productModule.Kd11.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                productModule.Kd22.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                productModule.PG.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                productModule.PK.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                productModule.FPG.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                //productModule.FPK.Text = dgvOrder.Rows[e.RowIndex].Cells[12].Value.ToString();
                productModule.NPG.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                //productModule.NPK.Text = dgvOrder.Rows[e.RowIndex].Cells[14].Value.ToString();
                productModule.txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
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
                    cm = new SqlCommand("DELETE FROM Korder WHERE ordid LIKE '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
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
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                double total1 = 0;
                double total2 = 0;
                double total3 = 0;
                double total4 = 0;
                int n = 0;
                dataGridView1.Rows.Clear();
                cm = new SqlCommand("SELECT ordid,KID, date, Kname, Knum, Kmark, date1, date2, priceG,FpriceG,SpriceG,kphone,priceK,tak FROM Korder WHERE Kname=@username ", con);
                cm.Parameters.AddWithValue("@username", textBox1.Text);
                //cm.Parameters.AddWithValue("@password", txtSearch.Text);

                con.Open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    n++;
                    dataGridView1.Rows.Add(n, dr[0].ToString(), dr[1].ToString(), Convert.ToDateTime(dr[2].ToString()).ToString("dd/MM/yyyy"), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToDateTime(dr[6].ToString()).ToString("dd/MM/yyyy"), Convert.ToDateTime(dr[7].ToString()).ToString("dd/MM/yyyy"), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString(), dr[12].ToString(), dr[13].ToString());
                    total1 += Convert.ToInt32(dr[8].ToString());
                    total2 += Convert.ToInt32(dr[4].ToString());
                    total3 += Convert.ToInt32(dr[9].ToString());
                    total4 += Convert.ToInt32(dr[10].ToString());
                    //total3 += Convert.ToInt32(dr[6].ToString());
                }

                dr.Close();
                con.Close();
                label21.Text = n.ToString();
                label23.Text = total1.ToString();
                label29.Text = total1.ToString();
                label15.Text = total2.ToString();
                //double total5 = total1 - total;
                label11.Text = total1.ToString();
                label32.Text = total3.ToString();
                label34.Text = total4.ToString();
                double tot = total4 - total3;
                label41.Text = tot.ToString();

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                double total1 = 0;
                double total2 = 0;
                double total3 = 0;
                double total4 = 0;
                int n = 0;
                dataGridView1.Rows.Clear();
                cm = new SqlCommand("SELECT ordid,KID, date, Kname, Knum, Kmark, date1, date2, priceG,FpriceG,SpriceG,kphone,priceK,tak FROM Korder WHERE Kmark=@username ", con);
                cm.Parameters.AddWithValue("@username", textBox1.Text);
                //cm.Parameters.AddWithValue("@password", txtSearch.Text);

                con.Open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    n++;
                    dataGridView1.Rows.Add(n, dr[0].ToString(), dr[1].ToString(), Convert.ToDateTime(dr[2].ToString()).ToString("dd/MM/yyyy"), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToDateTime(dr[6].ToString()).ToString("dd/MM/yyyy"), Convert.ToDateTime(dr[7].ToString()).ToString("dd/MM/yyyy"), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString(), dr[12].ToString(), dr[13].ToString());
                    total1 += Convert.ToInt32(dr[8].ToString());
                    total2 += Convert.ToInt32(dr[4].ToString());
                    total3 += Convert.ToInt32(dr[9].ToString());
                    total4 += Convert.ToInt32(dr[10].ToString());
                    //total3 += Convert.ToInt32(dr[6].ToString());
                }

                dr.Close();
                con.Close();
                label21.Text = n.ToString();
                label23.Text = total1.ToString();
                label29.Text = total1.ToString();
                label15.Text = total2.ToString();
                //double total5 = total1 - total;
                label11.Text = total1.ToString();
                label32.Text = total3.ToString();
                label34.Text = total4.ToString();
                double tot = total4 - total3;
                label41.Text = tot.ToString();

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
