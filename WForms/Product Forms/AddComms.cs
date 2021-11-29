using DAL.ADO;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace WForms.Product_Forms
{
    public partial class AddComms : Form
    {
        public AddComms()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new CommsDal(connStr);
            int i = Int32.Parse(textBox1.Text);
            int i2 = Int32.Parse(textBox2.Text);
            string ms = textBox3.Text;
            var Product = new DTO.CommsDTO
            {
                OrderID = i,
                ClientID = i2,
                MS = ms

            };
            p.CreateComms(Product);
            this.Hide();
        }
    }
}
