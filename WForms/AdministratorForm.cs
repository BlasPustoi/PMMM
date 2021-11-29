using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BusinessLogic;
using WForms.Product_Forms;

namespace WForms
{
    public partial class AdministratorForm : Form
    {
        public AdministratorForm()
        {
            InitializeComponent();
        }

        private void AdministratorForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDataSet.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.shopDataSet.Client);
            // TODO: This line of code loads data into the 'shopDataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.shopDataSet.Product);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString))
            {
                try
                {
                    string Combo = comboBox1.Text;
                    button2.Text = "Add " + Combo;
                    button3.Text = "Delete " + Combo;
                    button4.Text = "Update " + Combo;
                    Combo = Helper.Combo_fix(Combo);
                    sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from " + Combo, sqlCon);

                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                    
                }
                catch
                {

                }
            }
        }
        private void refresh()
        {
            this.refresh();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string c = button2.Text;
            switch (c)
            {
                case "Add Products": new AddProduct().Show(); break;
                case "Add Clients": new AddClient().Show(); break;
                case "Add Orders": new AddOrder().Show(); break;
                case "Add History": new AddHistory().Show(); break;
                case "Add Comms": new AddComms().Show(); break;
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string c = button3.Text;
            switch (c)
            {
                case "Delete Products": new DeleteProduct().Show(); break;
                case "Delete Clients": new DeleteClient().Show(); break;
                case "Delete Orders": new DeleteOrder().Show(); break;
                case "Delete History": new DeleteHistory().Show(); break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string c = button4.Text;
            switch (c)
            {
                case "Update Products": new UpdateProduct().Show(); break;
                case "Update Clients": new UpdateClient().Show(); break;
                case "Update Orders": new UpdateOrder().Show(); break;
                case "Update History": new UpdateHistory().Show(); break;
            }
        }
    }
}
