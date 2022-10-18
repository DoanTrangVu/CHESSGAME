using CHESSGAME.Controllers;
using CHESSGAME.Controllers.Sockets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CHESSGAME.Controllers.ChessBoardManager;

namespace CHESSGAME.Views
{
    public partial class frmChessGame : Form
    {
        #region Properties
        ChessBoardManager ChessBoard;
        SocketManager socket;
        frmLogin frm_main;
        #endregion
        public frmChessGame(frmLogin frmLogin)
        {
            InitializeComponent();
            this.frm_main = frmLogin;
            ChessBoard = new ChessBoardManager(pnlChessBoard, pctPlayerBlack, lblNamePlayerBlack, pctPlayerPink, lblNamePlayerPink, dgvListMove);
            NewGame();
            //ChessBoard.isReady();
        }
        #region Methods
        
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
            Control.CheckForIllegalCrossThreadCalls = false;
            ChessBoard = new ChessBoardManager(pnlChessBoard, pctPlayerBlack, lblNamePlayerBlack, pctPlayerPink, lblNamePlayerPink, dgvListMove);
            ChessBoard.PlayerPieceMarked += ChessBoard_PlayerPieceMarked;
            socket = new SocketManager();
            NewGame();
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
        //public Thread cdt1, cdt2;
        //public int num1, num2;
        //public bool flagSypend1, flagSypend2;
        private void btnStartTime_Click(object sender, EventArgs e)
        {
            
        }

        private void tmrBlack_Tick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLAN_Click(object sender, EventArgs e)
        {
            socket.IP = txtIP.Text;
            int a = 1;
            if (!socket.ConnectServer())
            {
                socket.isServer = true;
                pnlChessBoard.Enabled = true;
                socket.CreateServer();
            }
            else
            {
                socket.isServer = false;
                pnlChessBoard.Enabled = false;
                Listen();
            }
            if
        }
        void Listen()
        {
            SocketData data;
            Thread listenThread = new Thread(() =>
            {
                try
                {
                    data = (SocketData)socket.Receive();

                    ProcessData(data);
                }
                catch (Exception e)
                {

                }
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }
        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;

                case (int)SocketCommand.NEW_GAME:
                    break;
                case (int)SocketCommand.UNDO:
                    break;

                case (int)SocketCommand.QUIT:
                    break;
                case (int)SocketCommand.SEND_PIECE:
                    {
                        this.Invoke((MethodInvoker)(() =>
                        {
                            pnlChessBoard.Enabled = true;
                            ChessBoard.OtherPlayerMark(data.Point, data.StartPoint);
                        }));
                    }
                    break;
                default:
                    break;
            }
            Listen();
        }
        void ChessBoard_PlayerPieceMarked(object sender, ButtonPieceClickEvent e)
        {
            pnlChessBoard.Enabled = false;
            socket.Send(new SocketData((int)SocketCommand.SEND_PIECE, "", e.ClickedPoint, e.StartPoint));
            Listen();
        }
        private void frmChessGame_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            ChessBoard = new ChessBoardManager(pnlChessBoard, pctPlayerBlack, lblNamePlayerBlack, pctPlayerPink, lblNamePlayerPink, dgvListMove);
            ChessBoard.PlayerPieceMarked += ChessBoard_PlayerPieceMarked;
            socket = new SocketManager();
            NewGame();
        }

        private void frmChessGame_Shown(object sender, EventArgs e)
        {
            txtIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(txtIP.Text))
            {
                txtIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }
    }
}
