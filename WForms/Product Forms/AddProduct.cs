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
using DAL.ADO;
using DTO;

namespace WForms
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int cost = Int32.Parse(textBox2.Text);
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new ProductDal(connStr);
            p.CreateProduct(new ProductDTO { Name = name, Cost = cost });
            this.Hide();
        }
    }
}
