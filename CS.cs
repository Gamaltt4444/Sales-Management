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
    public partial class CS : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = aserzamzam12; Integrated Security = True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public DataTable dc = new DataTable();
        public DataTable DtPublic = new DataTable();
        public CS()
        {
            InitializeComponent();
            loadCustomer();


        }
        public void loadPublic(string SPtext)
        {
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = SPtext;
            con.Open();
            DtPublic.Load(cm.ExecuteReader());

            con.Close();

        }
        public void SharchCustomer(string txt)
        {
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "SharchCustomer";
            cm.Parameters.Add("@txt", SqlDbType.VarChar, 50).Value = txt;
            con.Open();
            dc.Load(cm.ExecuteReader());

            con.Close();

        }
        void loadCustomer()
        {
            CS Lc = new CS();
            Lc.loadPublic("loadCustomer");
            dataGridView1.DataSource = Lc.DtPublic;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CS or = new CS();
            or.SharchCustomer(textBox1.Text);
            dataGridView1.DataSource = or.dc;
        }
    }
}
