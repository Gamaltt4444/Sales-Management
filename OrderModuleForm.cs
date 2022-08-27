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
    public partial class OrderModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = aserzamzam12; Integrated Security = True");
        //SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        int qty = 0;
        public OrderModuleForm()
        {
            InitializeComponent();
            LoadCustomer();
            LoadProduct();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
           
        }

        public void LoadCustomer()
        {
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT cid, cname FROM tbCustomer WHERE CONCAT(cid,cname) LIKE '%"+txtSearchCust.Text+"%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
        }

        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT pid, pname, pprice, pdescription, pcategory FROM tbProduct WHERE CONCAT(pid, pname, pprice, pdescription, pcategory) LIKE '%" + txtSearchProd.Text + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void txtSearchCust_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void txtSearchProd_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GetQty();
           
            if (Convert.ToInt16(UDQty.Value) > 0)
            {
                int total = Convert.ToInt16(txtPrice.Text) * Convert.ToInt16(UDQty.Value);
                txtTotal.Text = total.ToString();
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCId.Text = "1";

                dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCName.Text = "زمزم";
                dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();            
        }

      

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (textname.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل اسم صاحب الكوريك", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("هل انت متاكد من اجراء هذا الطلب؟", "جاري الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //ordid, date, Kname, Knum, Kmark, date1, date2, priceG,priceK,FpriceG,FpriceK,SpriceG,SpriceK FROM Korder

                    cm = new SqlCommand("INSERT INTO Korder(date, Kname, Knum, Kmark,date1,date2,priceG,priceK,FpriceG,FpriceK,SpriceG,SpriceK)VALUES(@date,@Kname,@Knum,@Kmark,@date1,@date2,@priceG,@priceK,@FpriceG,@FpriceK,@SpriceG,@SpriceK)", con);
                    cm.Parameters.AddWithValue("@odate", date.Value);
                    //cm.Parameters.AddWithValue("@ordid", Convert.ToInt32(txtPid.Text));
                    cm.Parameters.AddWithValue("@Kname", Convert.ToInt32(textname.Text));
                    cm.Parameters.AddWithValue("@Knum", Convert.ToInt32(Knum.Value));
                    cm.Parameters.AddWithValue("@Kmark", Convert.ToInt32(Kmark.Text));
                    cm.Parameters.AddWithValue("@date1", kd1.Value);
                    cm.Parameters.AddWithValue("@date2", Kd2.Value);
                    cm.Parameters.AddWithValue("@priceG", Convert.ToInt32(PG.Text));
                    cm.Parameters.AddWithValue("@pricek", Convert.ToInt32(PK.Text));
                    cm.Parameters.AddWithValue("@FpriceG", Convert.ToInt32(FPG.Text));
                    cm.Parameters.AddWithValue("@FpriceK", Convert.ToInt32(FPK.Text));
                    cm.Parameters.AddWithValue("@SpriceG", Convert.ToInt32(NPG.Text));
                    cm.Parameters.AddWithValue("@SpriceK", Convert.ToInt32(NPK.Text));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم اجراء الاوردر بنجاح");
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                    printPreviewDialog1.Document = this.printDocument1;
                    printPreviewDialog1.FormBorderStyle = FormBorderStyle.Fixed3D;
                    //printPreviewDialog1.SetBounds(20, 20, this.Width, this.Height);

                    printPreviewDialog1.ShowDialog();


                    //cm = new SqlCommand("UPDATE tbProduct SET pqty=(pqty-@pqty) WHERE pid LIKE '"+ txtPid.Text +"' ", con);                    
                    //cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(UDQty.Value));
                   
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    Clear();
                    LoadProduct();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void Clear()
        {
            txtPid.Clear();
            textname.Clear();
            Kmark.Clear();
            PG.Clear();
            PK.Clear();
            FPG.Clear();
            FPK.Clear();
            NPG.Clear();
            NPK.Clear();
            Knum.Value = 0;
            date.Value = DateTime.Now;
            kd1.Value = DateTime.Now;
            Kd2.Value = DateTime.Now;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();                        
        }

        public void GetQty()
        {
            cm = new SqlCommand("SELECT pqty FROM tbProduct WHERE pid='"+ txtPid.Text +"'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                qty = Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float yPos = 8;
            int leftMargin = 15;
            // Pen pen = new Pen(Brushes.Black);

            //e.HasMorePages =true;
            // pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            //Font printFont4d = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
            //Font printFont = new System.Drawing.Font("Times New Roman", 14);
            //Font printFont11 = new System.Drawing.Font("Times New Roman", 16);
            //Font printFontFoorer = new System.Drawing.Font("Times New Roman", 12);
            //Font printFontheader_DRName = new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold);
            //------
           

            Font PatientFontheader = new System.Drawing.Font("Times New Roman", 30, FontStyle.Bold);
            Font PatientFontheader1 = new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold);

            Font PatientNormal = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            //======================================                      

            //yPos += 152;
            e.Graphics.DrawString("عصير زمزم", PatientFontheader, Brushes.Black, leftMargin + 340, 30, new StringFormat());
           // e.Graphics.DrawString("عصير زمزم", PatientFontheader, Brushes.Black, leftMargin + 360 ,30, new StringFormat());
            //e.Graphics.DrawString(": اسم الصنف", PatientFontheader1, Brushes.Black, leftMargin + 450, 100, new StringFormat());
            e.Graphics.DrawString(txtPName.Text, PatientFontheader1, Brushes.Black, leftMargin + 340, 100, new StringFormat());

            e.Graphics.DrawString(": سعر الكوب", PatientFontheader1, Brushes.Black, leftMargin + 400,150 , new StringFormat());
            e.Graphics.DrawString(txtPrice.Text, PatientFontheader1, Brushes.Black, leftMargin + 350,150 , new StringFormat());

            e.Graphics.DrawString(": الكميه", PatientFontheader1, Brushes.Black, leftMargin + 400, 200, new StringFormat());
            e.Graphics.DrawString(UDQty.Text, PatientFontheader1, Brushes.Black, leftMargin + 350, 200, new StringFormat());
            e.Graphics.DrawString(": الاجمالي", PatientFontheader1, Brushes.Black, leftMargin + 400, 250, new StringFormat());
            e.Graphics.DrawString(txtTotal.Text, PatientFontheader1, Brushes.Black, leftMargin + 350, 250, new StringFormat());
            yPos += 25;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
