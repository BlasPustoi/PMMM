using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BusinessLogic;
using System.Configuration;

namespace WForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (button1.Text == "Login")
                {


                    string log = textBox1.Text;
                    string pass = textBox2.Text;
                    UserDTO a = new UserDTO
                    {
                        login = log,
                        password = pass
                    };
                    var p = new UserLogic(ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString);

                    if (p.Login(a)&&(p.RoleCheck(a)==1))
                    {
                        this.Hide();
                        var Nf = new AdministratorForm();
                        Nf.Show();
                    }else if (p.Login(a) && (p.RoleCheck(a) == 0))
                    {
                        this.Hide();
                        var NWF = new UserForm();
                        NWF.Show();
                    }
                }
                else
                {
                    string log = textBox1.Text;
                    string pass = textBox2.Text;
                    UserDTO a = new UserDTO
                    {
                        login = log,
                        password = pass
                    };
                    var p = new UserLogic(ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString);
                    p.CreateUser(a);
                    button1.Text = "Login";
                }
            }
            catch
            {
                
                
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
                button1.Text = "Register";
        }
    }
}
