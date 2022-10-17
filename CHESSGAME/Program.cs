using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CHESSGAME.Views;

namespace CHESSGAME
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmChessGame(frmLogin));
            Application.Run(new frmLogin());
            //Application.Run(new frmRegister());
        }
    }
}
