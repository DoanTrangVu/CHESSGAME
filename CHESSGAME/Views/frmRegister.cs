using CHESSGAME.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CHESSGAME.Views
{
    public partial class frmRegister : Form
    {
        frmLogin frm_main;
        public frmRegister(frmLogin frmLogin)
        {
            InitializeComponent();
            this.frm_main = frmLogin;
        }
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 context = new Model1();
                if (txtUsername.Text == "" || txtComfirmPassword.Text == "" || txtPassword.Text == "")
                    throw new Exception("Please enter your Username and Password!!!");
                if (txtComfirmPassword.Text == txtPassword.Text)
                {
                    ManageUser find = context.ManageUsers.FirstOrDefault(p => p.Username == txtUsername.Text);
                    if (find == null)
                    {
                        ManageUser u = new ManageUser()
                        { Username = txtUsername.Text, Password = txtComfirmPassword.Text };
                        context.ManageUsers.Add(u);
                        context.SaveChanges();
                        MessageBox.Show("Register successfully!!!", "Notification", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username existed!!!", "Notification", MessageBoxButtons.OK);
                    }
                }
                else
                    MessageBox.Show("Comfirm password again!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
