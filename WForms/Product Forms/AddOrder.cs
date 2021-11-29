using DAL.ADO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WForms.Product_Forms
{
    public partial class AddOrder : Form
    {
        public AddOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new OrderDal(connStr);
            int CID = Int32.Parse(textBox1.Text);
            int PID = Int32.Parse(textBox2.Text);
            var Product = new DTO.OrderDTO
            {
                OrderID = 0,
                ClientID = CID,
                ProductID = PID,
                Time = DateTime.Now
            };
            p.CreateOrder(Product);
            this.Hide();
        }
    }
}
