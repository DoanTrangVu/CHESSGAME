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
        public Boolean isChoosePiece = false;
        public Panel ChessBoard
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }
        private List<Player> player;
        public List<Player> Player
        {
            get { return player; }
            set { player = value; }
        }
        private Side currentPlayer;
        public Side CurrentPlayer 
        { 
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }
        private PictureBox pctPlayerBlack;
        public PictureBox PctPlayerBlack
        {
            get { return pctPlayerBlack; }
            set { pctPlayerBlack = value; }
        }
        private PictureBox pctPlayerPink;
        public PictureBox PctPlayerPink
        {
            get { return pctPlayerPink; }
            set { pctPlayerPink = value; }
        }
        private Label lblNamePlayerPink;
        public Label LblNamePlayerPink
        {
            get { return lblNamePlayerPink; }
            set { lblNamePlayerPink = value; }
        }
        private Label lblNamePlayerBlack;
        public Label LblNamePlayerBlack
        {
            get { return lblNamePlayerBlack; }
            set { lblNamePlayerBlack = value; }
        }
        #endregion

        #region Initialize
        public ChessBoardManager(Panel chessBoard, PictureBox pctPlayerBlack, Label lblNamePlayerBlack, PictureBox pctPlayerPink, Label lblNamePlayerPink)
        {
            this.ChessBoard = chessBoard;
            this.PctPlayerBlack = pctPlayerBlack;
            this.PctPlayerPink = pctPlayerPink;
            this.LblNamePlayerBlack = lblNamePlayerBlack;
            this.LblNamePlayerPink = lblNamePlayerPink;

            this.Player = new List<Player>()
            {
                //new Player ("user1", Image.FromFile(Application.StartupPath + "\\Resources\\B_Pawn.png")),
                //new Player ("user2", Image.FromFile(Application.StartupPath + "\\Resources\\P_Pawn.png"))
            };
            CurrentPlayer = Side.Pink;
            pctPlayerPink.BackColor = Color.Red;
        }
        #endregion

        #region Methods
        // List Contains all Square
        List<Square> squares = new List<Square>();
        public void DrawChessBoard()
        {
            ChessBoard.Controls.Clear();
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
                        Location = new Location() { Row = number, Col = (Chars)j },
                        Color = btn.BackColor
                    };
                    pieces.Add(square);
                    //square.Button.Text = square.Location.Row.ToString() + square.Location.Col;

                    if (square.Location.Row == 8 && (square.Location.Col == Chars.A || square.Location.Col == Chars.H))
                    {
                        square.Piece = new Castle()
                        {
                            Side = Side.Black,
                            Square = square
                        };
                        var image = square.Piece.GetImage();
                        Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(image);
                        square.Button.BackgroundImage = img;
                        square.Button.BackgroundImageLayout = ImageLayout.Stretch;
                        //square.Button.Text = square.Piece.Name + square.Piece.Side;
                    }
                    if (square.Location.Row == 8 && (square.Location.Col == Chars.B || square.Location.Col == Chars.G))
                    {
                        square.Piece = new Knight()
                        {
                            Side = Side.Black,
                            Square = square
                        };
                        var image = square.Piece.GetImage();
                        Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(image);
                        square.Button.BackgroundImage = img;
                        square.Button.BackgroundImageLayout = ImageLayout.Stretch;
                        //square.Button.Text = square.Piece.Name + square.Piece.Side;
                    }
                    if (square.Location.Row == 8 && (square.Location.Col == Chars.C || square.Location.Col == Chars.F))
                    {
                        square.Piece = new Bishop()
                        {
                            Side = Side.Black,
                            Square = square
                        };
                        var image = square.Piece.GetImage();
                        Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(image);
                        square.Button.BackgroundImage = img;
                        square.Button.BackgroundImageLayout = ImageLayout.Stretch;
                        //square.Button.Text = square.Piece.Name + square.Piece.Side;
                    }
                    if (square.Location.Row == 8 && square.Location.Col == Chars.D)
                    {
                        square.Piece = new King()
                        {
                            Side = Side.Black,
                            Square = square
                        };
                        var image = square.Piece.GetImage();
                        Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(image);
                        square.Button.BackgroundImage = img;
                        square.Button.BackgroundImageLayout = ImageLayout.Stretch;
                        //square.Button.Text = square.Piece.Name + square.Piece.Side;
                    }
                    if (square.Location.Row == 8 && square.Location.Col == Chars.E)
                    {
                        square.Piece = new Queen()
                        {
                            Side = Side.Black,
                            Square = square
                        };
                        var image = square.Piece.GetImage();
                        Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(image);
                        square.Button.BackgroundImage = img;
                        square.Button.BackgroundImageLayout = ImageLayout.Stretch;
                        //square.Button.Text = square.Piece.Name + square.Piece.Side;
                    }
                    if (square.Location.Row == 7)
                    {
                        square.Piece = new Pawn()
                        {
                            Side = Side.Black,
                            Square = square
                        };
                        var image = square.Piece.GetImage();
                        Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(image);
                        square.Button.BackgroundImage = img;
                        square.Button.BackgroundImageLayout = ImageLayout.Stretch;
                        //square.Button.Text = square.Piece.Name + square.Piece.Side;
                    }
                    if (square.Location.Row == 1 && (square.Location.Col == Chars.A || square.Location.Col == Chars.H))
                    {
                        square.Piece = new Castle()
                        {
                            Side = Side.Pink,
                            Square = square
                        };
                        var image = square.Piece.GetImage();
                        Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(image);
                        square.Button.BackgroundImage = img;
                        square.Button.BackgroundImageLayout = ImageLayout.Stretch;
                        //square.Button.Text = square.Piece.Name + square.Piece.Side;
                    }
                    if (square.Location.Row == 1 && (square.Location.Col == Chars.B || square.Location.Col == Chars.G))
                    {
                        square.Piece = new Knight()
                        {
                            Side = Side.Pink,
                            Square = square
                        };
                        var image = square.Piece.GetImage();
                        Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(image);
                        square.Button.BackgroundImage = img;
                        square.Button.BackgroundImageLayout = ImageLayout.Stretch;
                        //square.Button.Text = square.Piece.Name + square.Piece.Side;
                    }
                    if (square.Location.Row == 1 && (square.Location.Col == Chars.C || square.Location.Col == Chars.F))
                    {
                        square.Piece = new Bishop()
                        {
                            Side = Side.Pink,
                            Square = square
                        };
                        var image = square.Piece.GetImage();
                        Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(image);
                        square.Button.BackgroundImage = img;
                        square.Button.BackgroundImageLayout = ImageLayout.Stretch;
                        //square.Button.Text = square.Piece.Name + square.Piece.Side;
                    }
                    if (square.Location.Row == 1 && square.Location.Col == Chars.D)
                    {
                        square.Piece = new Queen()
                        {
                            Side = Side.Pink,
                            Square = square
                        };
                        var image = square.Piece.GetImage();
                        Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(image);
                        square.Button.BackgroundImage = img;
                        square.Button.BackgroundImageLayout = ImageLayout.Stretch;
                        //square.Button.Text = square.Piece.Name + square.Piece.Side;
                    }
                    if (square.Location.Row == 1 && square.Location.Col == Chars.E)
                    {
                        square.Piece = new King()
                        {
                            Side = Side.Pink,
                            Square = square
                        };
                        var image = square.Piece.GetImage();
                        Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(image);
                        square.Button.BackgroundImage = img;
                        square.Button.BackgroundImageLayout = ImageLayout.Stretch;
                        //square.Button.Text = square.Piece.Name + square.Piece.Side;
                    }
                    if (square.Location.Row == 2)
                    {
                        square.Piece = new Pawn() 
                        { 
                            Side = Side.Pink,
                            Square = square
                        };
                        var image = square.Piece.GetImage();
                        Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(image);
                        square.Button.BackgroundImage = img;
                        square.Button.BackgroundImageLayout = ImageLayout.Stretch;
                        //square.Button.Text = square.Piece.Name + square.Piece.Side;
                    }
                    // Add Button
                    ChessBoard.Controls.Add(btn);
                    // Add Square
                    squares.Add(square);
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
        Piece currentPiece;
        List<Square> legalSquares = new List<Square>();
        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            // Disable Board
            //squares.ForEach(s => s.Disable());
            //Disable Board

            // Get Square that has this button (btn)
            var currentSquare = squares.Where(s => s.Button.Equals(btn)).FirstOrDefault();
            if (currentSquare.Piece != null)
            {
                if (currentSquare.Piece.Side != currentPlayer && !isChoosePiece)
                {
                    return;
                }
            }
            

            //Return when a piece is being chosen
            if ((isChoosePiece && currentSquare.Piece != currentPiece && !legalSquares.Contains(currentSquare)))
            {
                return;
            }
            if (currentSquare == null)
            {
                MessageBox.Show("Cannot found!");
                return;
            }

            bool isUpdate = false;
            if (legalSquares.Contains(currentSquare))
            {
                currentPiece.UpdateLocation(currentSquare);
                ChangePlayer();
                squares.ForEach(s => s.ResetColor());
                legalSquares.Clear();
                isUpdate = true;   
            }
            if (currentSquare.Piece == null)
            {
                return;
            }
            // Get all Legal Location
            var locations = currentSquare.Piece.GetLegalLocations(currentSquare);
            // Each Legal Location change that Square's BackColor to Red
            locations.ForEach(l =>
            {
                var legalSquare = squares.Find(sq => sq.Location.Row == l.Row 
                && sq.Location.Col == l.Col 
                && (sq.Piece == null || sq.Piece.Side != currentSquare.Piece.Side));
                //MessageBox.Show($"|{legalSquare}|");
                if (legalSquare != null)
                {
                    if (btn.FlatAppearance.BorderColor == Color.Red || isUpdate)
                    {
                        legalSquare.ResetColor();
                        isChoosePiece = false;
                        legalSquares.Remove(legalSquare);
                    }
                    else
                    {
                        legalSquare.Button.BackColor = Color.Red;
                        legalSquares.Add(legalSquare);
                    }
                }
            });
            if (currentSquare.IsClick && !isUpdate)
            {
                currentSquare.UnSelect();
                isChoosePiece = false;
                currentSquare.IsClick = false;
            }
            else if (!currentSquare.IsClick && !isUpdate)
            {
                currentSquare.Select();
                isChoosePiece = true;
                currentPiece = currentSquare.Piece;
                currentSquare.IsClick = true;
            }
        }
        private void ChangePlayer()
        {
            currentPlayer = currentPlayer == Side.Pink ? Side.Black : Side.Pink;
            if (currentPlayer == Side.Pink)
            {
                pctPlayerPink.BackColor = Color.Red;
                pctPlayerBlack.BackColor = Color.Transparent;
            }
            else
            {
                pctPlayerBlack.BackColor = Color.Red;
                pctPlayerPink.BackColor = Color.Transparent;
            }

        }
        #endregion
    }
}
