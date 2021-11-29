using DAL.ADO;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace WForms.Product_Forms
{
    public partial class UpdateHistory : Form
    {
        public UpdateHistory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new HistoryDal(connStr);
            int i = Int32.Parse(textBox2.Text);
            bool Finish = bool.Parse(textBox3.Text);
            label2.Text = "Doof";
            var Product = new DTO.HistoryDTO
            {
                OrderID = i,
                finished = Finish
            };
            p.UpdateHistory(Product);
            this.Hide();
        }
    }
}
