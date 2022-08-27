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
    public partial class Korder : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = aserzamzam12; Integrated Security = True");
        //SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();

        public Korder()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void Clear()
        {
            //txtPid.Clear();
            textname.Clear();
            txtPhone.Clear();
            ID.Clear();
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
            kd2.Value = DateTime.Now;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            Kd11.Visible = false;
            Kd22.Visible = false;
            kd1.Visible = true;
            kd2.Visible = true;

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            try
            {
                

                if (ID.Text == "") 
                {
                    MessageBox.Show("من فضلك ادخل رقم الكوريك", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Knum.Text == "0")
                {
                    MessageBox.Show("من فضلك ادخل عدد الكواريك", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Kmark.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل ماركة الكوريك", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   return;
                }
                if (txtPhone.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل رقم التلفون", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (PG.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل المبلغ بالجينة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //if (PK.Text == "")
                //{
                   // MessageBox.Show("من فضلك ادخل المبلغ بالقرش", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return;
                //}
                if (FPG.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل العربون بالجينة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
               // if (FPK.Text == "")
               // {
                //    MessageBox.Show("من فضلك ادخل العربون بالقرش", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  //  return;
               // }
                if (NPG.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل الباقي بالجينة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
               // if (NPK.Text == "")
               // {
                   // MessageBox.Show("من فضلك ادخل الباقي بالقرش", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   // return;
               // }
                

                if (MessageBox.Show("هل انت متاكد من اجراء هذا الطلب؟", "جاري الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //ordid, date, Kname, Knum, Kmark, date1, date2, priceG,priceK,FpriceG,FpriceK,SpriceG,SpriceK FROM Korder

                    cm = new SqlCommand("INSERT INTO Korder(date,KID,Kname, Knum, Kmark,date1,date2,priceG,priceK,FpriceG,SpriceG,kphone)VALUES(@date,@KID ,@Kname,@Knum,@Kmark,@date1,@date2,@priceG,@priceK,@FpriceG,@SpriceG,@kphone)", con);
                    cm.Parameters.AddWithValue("@date", date.Value);
                    cm.Parameters.AddWithValue("@KID", Convert.ToInt32(ID.Text));
                    //cm.Parameters.AddWithValue("@ordid", Convert.ToInt32(txtPid.Text));
                    cm.Parameters.AddWithValue("@Kname", textname.Text);
                    cm.Parameters.AddWithValue("@kphone", txtPhone.Text);
                    cm.Parameters.AddWithValue("@Knum", Convert.ToInt32(Knum.Value));
                    cm.Parameters.AddWithValue("@Kmark", Kmark.Text);
                    cm.Parameters.AddWithValue("@date1", kd1.Value);
                    cm.Parameters.AddWithValue("@date2", kd2.Value);
                    cm.Parameters.AddWithValue("@priceG", Convert.ToInt32(PG.Text));
                    cm.Parameters.AddWithValue("@pricek", PK.Text);
                    cm.Parameters.AddWithValue("@FpriceG", Convert.ToInt32(FPG.Text));
                    //cm.Parameters.AddWithValue("@FpriceK", Convert.ToInt32(FPK.Text));
                    cm.Parameters.AddWithValue("@SpriceG", Convert.ToInt32(NPG.Text));
                    //cm.Parameters.AddWithValue("@SpriceK", Convert.ToInt32(NPK.Text));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم اجراء الاوردر بنجاح");
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                    printPreviewDialog1.Document = this.printDocument1;
                    printPreviewDialog1.FormBorderStyle = FormBorderStyle.Fixed3D;
                    printPreviewDialog1.SetBounds(20, 20, this.Width, this.Height);

                   printPreviewDialog1.ShowDialog();


                    cm = new SqlCommand("UPDATE Korder SET Knum=(Knum-@pqty) WHERE date  LIKE '" + date.Value +"' ", con);                    
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(Km.Value));

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    Clear();
                    

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Image = new Bitmap(Image.png, new Size(227, 171));
           // e.Graphics.DrawImage(Properties.Resources.W, 300, 0, 550,400);
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
            Font PatientFontheader1 = new System.Drawing.Font("Times New Roman", 9, FontStyle.Bold);

            Font PatientNormal = new System.Drawing.Font("Arial", 12, FontStyle.Bold);

            //======================================
            yPos =160;
            e.Graphics.DrawString(ID.Text, PatientFontheader1, Brushes.Black, leftMargin +720,yPos, new StringFormat());
            yPos = 190;
            e.Graphics.DrawString(textname.Text, PatientFontheader1, Brushes.Black, leftMargin + 530, yPos, new StringFormat());
            yPos = 210;
            e.Graphics.DrawString(Knum.Text, PatientFontheader1, Brushes.Black, leftMargin + 620, yPos, new StringFormat());
            //e.Graphics.DrawString(PK.Text, PatientFontheader1, Brushes.Black, leftMargin + 20, 500, new StringFormat());
            yPos = 253;
            e.Graphics.DrawString(kd1.Text, PatientFontheader1, Brushes.Black, leftMargin + 570, yPos, new StringFormat());
            yPos = 273;
            e.Graphics.DrawString(kd2.Text, PatientFontheader1, Brushes.Black, leftMargin + 570, yPos, new StringFormat());
            e.Graphics.DrawString(PG.Text, PatientFontheader1, Brushes.Black, leftMargin + 300, 195, new StringFormat());
            //e.Graphics.DrawString(" , ", PatientFontheader1, Brushes.Black, leftMargin + 50, 385, new StringFormat());
            e.Graphics.DrawString(PK.Text, PatientFontheader1, Brushes.Black, leftMargin + 300, 5, new StringFormat());
            e.Graphics.DrawString(FPG.Text, PatientFontheader1, Brushes.Black, leftMargin + 300, 215, new StringFormat());
            //e.Graphics.DrawString(" , ", PatientFontheader1, Brushes.Black, leftMargin + 50, 425, new StringFormat());
           // e.Graphics.DrawString(FPK.Text, PatientFontheader1, Brushes.Black, leftMargin + 70, 425, new StringFormat());
            e.Graphics.DrawString(NPG.Text, PatientFontheader1, Brushes.Black, leftMargin + 300, 235, new StringFormat());
            //e.Graphics.DrawString(" , ", PatientFontheader1, Brushes.Black, leftMargin + 50, 465, new StringFormat());
            //e.Graphics.DrawString(NPK.Text, PatientFontheader1, Brushes.Black, leftMargin + 70, 465, new StringFormat());

            yPos += 25;

        

    }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("هل انت متاكد انك تريد تعديل هذا الوصل ؟", "جاري التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (kd1.Text== Kd11.Text)
                    {
                        if (kd2.Text == Kd22.Text)
                        {
                            cm = new SqlCommand("UPDATE Korder SET Kname = @Kname,KID = @KID,Knum=@Knum, Kmark=@Kmark, date1=@date1, date2=@date2, priceG=@priceG, priceK=@priceK, FpriceG=@FpriceG, SpriceG=@SpriceG,  kphone=@kphone WHERE ordid LIKE '" + lblPid.Text + "' ", con);
                            //cm.Parameters.AddWithValue("@date", date.Value);
                            //cm.Parameters.AddWithValue("@ordid", Convert.ToInt32(txtPid.Text));
                            cm.Parameters.AddWithValue("@Kname", textname.Text);
                            cm.Parameters.AddWithValue("@kphone", txtPhone.Text);
                            cm.Parameters.AddWithValue("@KID", Convert.ToInt32(ID.Text));
                            cm.Parameters.AddWithValue("@Knum", Convert.ToInt32(Knum.Value));
                            cm.Parameters.AddWithValue("@Kmark", Kmark.Text);
                            // Convert.ToDateTime(dr[1].ToString()).ToString("dd/MM/yyyy")
                            cm.Parameters.AddWithValue("@date1", kd1.Value);
                            cm.Parameters.AddWithValue("@date2", kd2.Value);
                            cm.Parameters.AddWithValue("@priceG", Convert.ToInt32(PG.Text));
                            cm.Parameters.AddWithValue("@pricek",PK.Text);
                            cm.Parameters.AddWithValue("@FpriceG", Convert.ToInt32(FPG.Text));
                            //cm.Parameters.AddWithValue("@FpriceK", Convert.ToInt32(FPK.Text));
                            cm.Parameters.AddWithValue("@SpriceG", Convert.ToInt32(NPG.Text));
                            //cm.Parameters.AddWithValue("@SpriceK", Convert.ToInt32(NPK.Text));
                            con.Open();
                            cm.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("تم التعديل بنجاح");
                            this.Dispose();
                            btnInsert.Enabled = true;
                            button1.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("يرجاء تعديل تاريخ التسليم والاستلام ؟", "خطأ");
               
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                try
                {


                    if (ID.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل رقم الكوريك", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (Knum.Text == "0")
                    {
                        MessageBox.Show("من فضلك ادخل عدد الكواريك", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (Kmark.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل ماركة الكوريك", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtPhone.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل رقم التلفون", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (PG.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل المبلغ بالجينة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                   // if (PK.Text == "")
                    //{
                      //  MessageBox.Show("من فضلك ادخل المبلغ بالقرش", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       // return;
                    //}
                    if (FPG.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل العربون بالجينة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //if (FPK.Text == "")
                    //{
                       // MessageBox.Show("من فضلك ادخل العربون بالقرش", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       // return;
                    //}
                    if (NPG.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل الباقي بالجينة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //if (NPK.Text == "")
                    //{
                        //MessageBox.Show("من فضلك ادخل الباقي بالقرش", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //return;
                    //}


                    if (MessageBox.Show("هل انت متاكد من اجراء هذا الطلب؟", "جاري الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //ordid, date, Kname, Knum, Kmark, date1, date2, priceG,priceK,FpriceG,FpriceK,SpriceG,SpriceK FROM Korder

                        cm = new SqlCommand("INSERT INTO Korder(date,KID,Kname, Knum, Kmark,date1,date2,priceG,priceK,FpriceG,SpriceG,kphone)VALUES(@date,@KID ,@Kname,@Knum,@Kmark,@date1,@date2,@priceG,@priceK,@FpriceG,@SpriceG,@kphone)", con);
                        cm.Parameters.AddWithValue("@date", date.Value);
                        cm.Parameters.AddWithValue("@KID", Convert.ToInt32(ID.Text));
                        //cm.Parameters.AddWithValue("@ordid", Convert.ToInt32(txtPid.Text));
                        cm.Parameters.AddWithValue("@Kname", textname.Text);
                        cm.Parameters.AddWithValue("@kphone", txtPhone.Text);
                        cm.Parameters.AddWithValue("@Knum", Convert.ToInt32(Knum.Value));
                        cm.Parameters.AddWithValue("@Kmark", Kmark.Text);
                        cm.Parameters.AddWithValue("@date1", kd1.Value);
                        cm.Parameters.AddWithValue("@date2", kd2.Value);
                        cm.Parameters.AddWithValue("@priceG", Convert.ToInt32(PG.Text));
                        cm.Parameters.AddWithValue("@pricek", PK.Text);
                        cm.Parameters.AddWithValue("@FpriceG", Convert.ToInt32(FPG.Text));
                      //cm.Parameters.AddWithValue("@FpriceK", Convert.ToInt32(FPK.Text));
                        cm.Parameters.AddWithValue("@SpriceG", Convert.ToInt32(NPG.Text));
                      //cm.Parameters.AddWithValue("@SpriceK", Convert.ToInt32(NPK.Text));
                        con.Open();
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("تم اجراء الاوردر بنجاح");
                        PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                        printPreviewDialog1.Document = this.printDocument2;
                        printPreviewDialog1.FormBorderStyle = FormBorderStyle.Fixed3D;
                        printPreviewDialog1.SetBounds(20, 20, this.Width, this.Height);

                        printPreviewDialog1.ShowDialog();


                        cm = new SqlCommand("UPDATE Korder SET Knum=(Knum-@pqty) WHERE date  LIKE '" + date.Value + "' ", con);
                        cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(Km.Value));

                        con.Open();
                        cm.ExecuteNonQuery();
                        con.Close();
                        Clear();


                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Image = new Bitmap(Image.png, new Size(227, 171));
           // e.Graphics.DrawImage(Properties.Resources.W, 300, 0, 550, 400);
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
            yPos = 160;
            e.Graphics.DrawString(ID.Text, PatientFontheader1, Brushes.Black, leftMargin + 720, yPos, new StringFormat());
            yPos = 190;
            e.Graphics.DrawString(textname.Text, PatientFontheader1, Brushes.Black, leftMargin + 530, yPos, new StringFormat());
            yPos = 210;
            e.Graphics.DrawString(Knum.Text, PatientFontheader1, Brushes.Black, leftMargin + 620, yPos, new StringFormat());
            //e.Graphics.DrawString(PK.Text, PatientFontheader1, Brushes.Black, leftMargin + 20, 500, new StringFormat());
            yPos = 230;
            e.Graphics.DrawString(Kmark.Text, PatientFontheader1, Brushes.Black, leftMargin + 530, yPos, new StringFormat());
            yPos = 253;
            e.Graphics.DrawString(kd1.Text, PatientFontheader1, Brushes.Black, leftMargin + 570, yPos, new StringFormat());
            yPos = 273;
            e.Graphics.DrawString(kd2.Text, PatientFontheader1, Brushes.Black, leftMargin + 570, yPos, new StringFormat());
            e.Graphics.DrawString(PG.Text, PatientFontheader1, Brushes.Black, leftMargin + 300, 195, new StringFormat());
            //e.Graphics.DrawString(" , ", PatientFontheader1, Brushes.Black, leftMargin + 50, 385, new StringFormat());
            e.Graphics.DrawString(PK.Text, PatientFontheader1, Brushes.Black, leftMargin + 300, 5, new StringFormat());
            e.Graphics.DrawString(FPG.Text, PatientFontheader1, Brushes.Black, leftMargin + 300, 215, new StringFormat());
            //e.Graphics.DrawString(" , ", PatientFontheader1, Brushes.Black, leftMargin + 50, 425, new StringFormat());
            // e.Graphics.DrawString(FPK.Text, PatientFontheader1, Brushes.Black, leftMargin + 70, 425, new StringFormat());
            e.Graphics.DrawString(NPG.Text, PatientFontheader1, Brushes.Black, leftMargin + 300, 235, new StringFormat());
            //e.Graphics.DrawString(" , ", PatientFontheader1, Brushes.Black, leftMargin + 50, 465, new StringFormat());
            //e.Graphics.DrawString(NPK.Text, PatientFontheader1, Brushes.Black, leftMargin + 70, 465, new StringFormat());
            

            yPos += 25;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cm = new SqlCommand("UPDATE Korder SET tak = @tak WHERE ordid LIKE '" + lblPid.Text + "' ", con);
              cm.Parameters.AddWithValue("@tak", textBox1.Text);
            con.Open();
            cm.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم التسليم  بنجاح");
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            btnInsert.Enabled = true;
        }
    }
    
}
