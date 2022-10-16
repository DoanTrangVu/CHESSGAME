using CHESSGAME.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHESSGAME.Controllers
{
    public class ChessBoardManager
    {
        #region Properties
        private Panel chessBoard;
        public Panel ChessBoard
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }
        #endregion

        #region Initialize
        public ChessBoardManager(Panel chessBoard)
        {
            this.ChessBoard = chessBoard;
        }
        #endregion

        #region Methods
        public void DrawChessBoard()
        {
            Button oldButton = new Button()
            {
                Width = 0,
                Location = new Point(30, 30),
                BackColor = Color.Silver,
                FlatStyle = FlatStyle.Flat,
            };
            var pieces = new List<Square>();
            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                var number = Cons.CHESS_BOARD_HEIGHT - i;
                for (int j = 0; j <= Cons.CHESS_BOARD_WIDTH; j++)
                {
                    //var character = (Chars)j;
                    Button btn = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new System.Drawing.Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    if (oldButton.BackColor == Color.Silver)
                        btn.BackColor = Color.WhiteSmoke;
                    else
                        btn.BackColor = Color.Silver;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Click += btn_Click;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    var square = new Square() 
                    { 
                        Button = btn, 
                        Location = new Location() { Row = number, Col = (Chars)j } 
                    };
                    pieces.Add(square);
                    //square.Button.Text = square.Location.Row.ToString() + square.Location.Col;

                    // Logic Render Pieces
                    if (square.Location.Row == 8 && (square.Location.Col == Chars.A || square.Location.Col == Chars.H))
                    {
                        square.Piece = new Castle()
                        {
                            Side = Side.Black,
                            Square = square
                        };
                        var image = square.Piece.GetImage();
                        //square.Button.BackgroundImage = Image.FromFile(Application.StartupPath + image);
                        square.Button.BackgroundImageLayout = ImageLayout.Stretch;
                        square.Button.Text = square.Piece.Name + square.Piece.Side;
                    }
                    if (square.Location.Row == 7)
                    {
                        square.Piece = new Pawn()
                        {
                            Side = Side.Black,
                            Square = square
                        };
                        var image = square.Piece.GetImage();
                        //square.Button.BackgroundImage = Image.FromFile(Application.StartupPath + image);
                        square.Button.BackgroundImageLayout = ImageLayout.Stretch;
                        square.Button.Text = square.Piece.Name + square.Piece.Side;
                    }

                    if (square.Location.Row == 2)
                    {
                        square.Piece = new Pawn() 
                        { 
                            Side = Side.White,
                            Square = square
                        };
                        var image = square.Piece.GetImage();
                        square.Button.BackgroundImageLayout = ImageLayout.Stretch;
                        square.Button.Text = square.Piece.Name + square.Piece.Side;
                    }

                    // Add Button
                    ChessBoard.Controls.Add(btn);
                    oldButton = btn;
                }
                oldButton.Location = new Point(30, oldButton.Location.Y + Cons.CHESS_HEIGHT);
                oldButton.Width = 0;
                oldButton.Height = 0;
                if (i % 2 == 0)
                    oldButton.BackColor = Color.WhiteSmoke;
                else
                    oldButton.BackColor = Color.Silver;
            }
        }
        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\B_Bishop.png");
            btn.FlatAppearance.BorderColor = Color.Red;
        }
        #endregion
    }
}
