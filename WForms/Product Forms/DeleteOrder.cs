using DAL.ADO;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace WForms.Product_Forms
{
    public partial class DeleteOrder : Form
    {
        public DeleteOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new OrderDal(connStr);
            int i = Int32.Parse(textBox1.Text);
            p.DeleteOrder(i);
            this.Hide();
        }
    }
}
