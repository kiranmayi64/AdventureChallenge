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

namespace Advworks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd"+" 00:00:00:000";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd" + " 00:00:00:000";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String con = "Data Source=KIRANVUNNAM;Initial Catalog=AdventureWorks2017;Integrated Security=True";
            SqlConnection s = new SqlConnection(con);
            s.Open();
            MessageBox.Show("Connected to DB");
            
            String q0 = "select AVG(TotalDue) As Average_Dollars from Purchasing.PurchaseOrderHeader where OrderDate BETWEEN "+"'"+ dateTimePicker1.Text+"'" + " AND " +"'"+dateTimePicker2.Text+"'" +" AND VendorID IN";
            String q1 = "(Select BusinessEntityID From Person.BusinessEntityAddress where AddressID IN ";
            String q2 = "(Select AddressID From Person.Address where PostalCode = " + "'"+int.Parse(textBox1.Text)+"'))";
            String q = q0 + q1 + q2;
            SqlCommand c = new SqlCommand(q, s);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = c;
            DataTable dbt = new DataTable();
            da.Fill(dbt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dbt;
            dataGridView1.DataSource = bs;
            da.Update(dbt);
           
        }
    }
}
