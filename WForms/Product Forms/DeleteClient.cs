using DAL.ADO;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace WForms.Product_Forms
{
    public partial class DeleteClient : Form
    {
        public DeleteClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID = Int32.Parse(textBox1.Text);
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new ClientDal(connStr);
            p.DeleteClient(ID);
            this.Hide();
        }
    }
}
