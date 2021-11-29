using DAL.ADO;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace WForms.Product_Forms
{
    public partial class UpdateOrder : Form
    {
        public UpdateOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new OrderDal(connStr);
            int i = Int32.Parse(textBox1.Text);
            int i2 = Int32.Parse(textBox2.Text);
            int i3 = Int32.Parse(textBox3.Text);
            DateTime dateTime = DateTime.Now;

            var Product = new DTO.OrderDTO
            {
                OrderID = i,
                ClientID = i2,
                ProductID = i3,
                Time = dateTime
            };
            p.UpdateOrder(Product);
            this.Hide();
        }
    }
}
