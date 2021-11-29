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

namespace WForms.Product_Forms
{
    public partial class DeleteProduct : Form
    {
        public DeleteProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID = Int32.Parse(textBox1.Text);
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new ProductDal(connStr);
            p.DeleteProduct(ID);
            this.Hide();

        }
    }
}
