using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Boolean status;
        private Entity.EntLogin login;
        private Implement.ImpLogin impLogin;

        public Form1()
        {
            impLogin = new Implement.ImpLogin();
            login = new Entity.EntLogin();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtKode.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Username dan Password Harus Diisi");
            }
            else
            {
                login.setKode(txtKode.Text);
                login.setPassword(txtPassword.Text);

                status = impLogin.Login(login);

                if(status == false)
                {
                    MessageBox.Show("Maaf Login Gagal");
                    txtKode.Text = "";
                    txtPassword.Text = "";
                    txtKode.Focus();
                }
                else
                {
                    Form2 f = new Form2();
                    f.Show();
                    this.Hide();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
