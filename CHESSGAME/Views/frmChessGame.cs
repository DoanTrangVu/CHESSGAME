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
        #endregion
        public frmChessGame()
        {
            InitializeComponent();
            ChessBoard = new ChessBoardManager(pnlChessBoard);
            ChessBoard.DrawChessBoard();
        }
        private void ChessGame_Load(object sender, EventArgs e)
        {

        }

    }
}
