using DAL.ADO;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace WForms
{
    public partial class DeleteHistory : Form
    {
        public DeleteHistory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new HistoryDal(connStr);
            int i = Int32.Parse(textBox1.Text);
            p.DeleteHistory(i);
            this.Hide();
        }
    }
}
