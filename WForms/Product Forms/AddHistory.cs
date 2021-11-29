using DAL.ADO;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace WForms.Product_Forms
{
    public partial class AddHistory : Form
    {
        public AddHistory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new HistoryDal(connStr);
            int i = Int32.Parse(textBox2.Text);
            bool status = bool.Parse(textBox1.Text);
            var Hist = new DTO.HistoryDTO
            {
                OrderID = i,
                finished = status

            };
            p.CreateHistory(Hist);
            this.Hide();
        }
    }
}
