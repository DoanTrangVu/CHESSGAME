using CHESSGAME.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHESSGAME.Views
{
    public partial class frmChessGame : Form
    {
        #region Properties
        ChessBoardManager ChessBoard;
        frmLogin frm_main;
        #endregion
        public frmChessGame(frmLogin frmLogin)
        {
            InitializeComponent();
            this.frm_main = frmLogin;
            ChessBoard = new ChessBoardManager(pnlChessBoard, pctPlayerBlack, lblNamePlayerBlack, pctPlayerPink, lblNamePlayerPink);
            NewGame();
        }
        #region Methods

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Text = "[" + e.X.ToString() + "," + e.Y.ToString() + "]";
        }
        void NewGame()
        {
            ChessBoard.DrawChessBoard();
        }
        void Quit()
        {
            Application.Exit();
        }
        void Undo()
        {

        }
        private void tlsNewGame_Click(object sender, EventArgs e)
        {
            //frmChessGame();
        }

        private void tlsQuit_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void tlsUndo_Click(object sender, EventArgs e)
        {

        }

        private void frmChessGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to quit this game?", "Notification", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }
        #endregion
    }
}
