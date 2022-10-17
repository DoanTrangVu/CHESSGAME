using CHESSGAME.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CHESSGAME.Views
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        public bool flag = false;
        private void btnStart_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1 ();
            var listUser = context.ManageUsers.ToList();
            var m = new ManageUser();
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please enter your Username and Password!!!");
            }
            else
            {
                for (int i = 0; i < listUser.Count(); i++)
                {
                    if ((txtUsername.Text == listUser[i].Username.ToString()) && (txtPassword.Text == listUser[i].Password.ToString()))
                    {
                        flag = true;
                        break;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                if (flag == false)
                {
                    MessageBox.Show("Please check your Username and Password!!!");
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                }
            }
            if (flag == true)
            {
                frmChessGame ChessGame = new frmChessGame(this);
                ChessGame.Show();
            }
        }
        
        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister Register = new frmRegister(this);
            Register.Show();
        }

    }
}
