using DAL.ADO;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace WForms.Product_Forms
{
    public partial class UpdateClient : Form
    {
        public UpdateClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            ClientDal p = new ClientDal(connStr);
            int i = Int32.Parse(textBox1.Text);
            string name = textBox2.Text;
            string phon = textBox3.Text;
            var Product = new DTO.ClientDTO
            {
                ClientID=i,
                name = name,
                phone=phon
            };
            Console.WriteLine("ok");
            p.UpdateClient(Product);
            this.Hide();
        }
    }
}
