using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Forms;
using DAL.ADO;

namespace WForms.Product_Forms
{
    public partial class UpdateProduct : Form
    {
        public UpdateProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            ProductDal p = new ProductDal(connStr);
            int i = Int32.Parse(textBox1.Text);
            string name = textBox2.Text;
            int cost =Int32.Parse(textBox3.Text);
            var Product = new DTO.ProductDTO
            {
                ProductID = i,
                Name = name,
                Cost = cost
            };
            Console.WriteLine("ok");
            p.UpdateProduct(Product);
            this.Hide();
        }
    }
}
