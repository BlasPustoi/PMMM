using System;
using System.Configuration;
using System.Windows.Forms;
using DAL.ADO;
using DTO;

namespace WForms.Product_Forms
{
    public partial class AddClient : Form
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string phon = textBox2.Text;
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new ClientDal(connStr);
            p.CreateClient(new ClientDTO { name=name,phone=phon});
            this.Hide();
        }
    }
}
