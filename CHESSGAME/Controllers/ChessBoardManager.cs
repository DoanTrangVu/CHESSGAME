using CHESSGAME.Controllers.Sockets;
using CHESSGAME.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;


namespace CHESSGAME.Controllers
{
    public class ChessBoardManager
    {
        #region Properties
        private Panel chessBoard;
        public Boolean isChoosePiece = false;
        public Thread cdt1, cdt2;
        public int num1, num2;
        public bool flagSypend1, flagSypend2;
        public Panel ChessBoard
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }
        private List<PlayInfo> player;
        public List<PlayInfo> Player
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
        private Label lblTimeBlack;
        public Label LblTimeBlack
        {
            get { return lblTimeBlack; }
            set { lblTimeBlack = value; }
        }
        private Label lblTimePink;
        public Label LblTimePink
        {
            get { return lblTimePink; }
            set { lblTimePink = value; }
        }
        public DataGridView dgvListMove;
        public DataGridView DgvListMove
        {
            get { return dgvListMove; }
            set { dgvListMove = value; }
        }
        private List<List<Button>> matrix;

        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        private event EventHandler<ButtonPieceClickEvent> playerPieceMarked;

        public event EventHandler<ButtonPieceClickEvent> PlayerPieceMarked
        {
            add
            {
                playerPieceMarked += value;
            }
            remove
            {
                playerPieceMarked -= value;
            }
        }
        private Stack<PlayInfo> playTimeLine;

        public Stack<PlayInfo> PlayTimeLine
        {
            get { return playTimeLine; }
            set { playTimeLine = value; }
        }
        #endregion

        #region Initialize
        public ChessBoardManager(Panel chessBoard, PictureBox pctPlayerBlack, 
            Label lblNamePlayerBlack, PictureBox pctPlayerPink, Label lblNamePlayerPink, DataGridView dgvListMove)
        {
            this.ChessBoard = chessBoard;
            this.PctPlayerBlack = pctPlayerBlack;
            this.PctPlayerPink = pctPlayerPink;
            this.LblNamePlayerBlack = lblNamePlayerBlack;
            this.LblNamePlayerPink = lblNamePlayerPink;
            this.DgvListMove = dgvListMove;

            this.Player = new List<PlayInfo>()
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
        public List<Square> squares = new List<Square>();
        public void DrawChessBoard()
        {
            ChessBoard.Enabled = true;
            PlayTimeLine = new Stack<PlayInfo>();
            Matrix = new List<List<Button>>();
            ChessBoard.Controls.Clear();
            //ChangePlayer();
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
                Matrix.Add(new List<Button>());
                var number = Cons.CHESS_BOARD_HEIGHT - i;
                for (int j = 0; j <= Cons.CHESS_BOARD_WIDTH; j++)
                {
                    //var character = (Chars)j;
                    Button btn = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new System.Drawing.Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString()
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
                        String move = square.Location.Row.ToString() + square.Location.Col;
                        String name = square.Piece.Side + "_" + square.Piece.Name;
                        SaveMove(name, move);
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
                        String move = square.Location.Row.ToString() + square.Location.Col;
                        String name = square.Piece.Side + "_" + square.Piece.Name;
                        SaveMove(name, move);
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
                        String move = square.Location.Row.ToString() + square.Location.Col;
                        String name = square.Piece.Side + "_" + square.Piece.Name;
                        SaveMove(name, move);
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
                        String move = square.Location.Row.ToString() + square.Location.Col;
                        String name = square.Piece.Side + "_" + square.Piece.Name;
                        SaveMove(name, move);
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
                        String move = square.Location.Row.ToString() + square.Location.Col;
                        String name = square.Piece.Side + "_" + square.Piece.Name;
                        SaveMove(name, move);
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
                        String move = square.Location.Row.ToString() + square.Location.Col;
                        String name = square.Piece.Side + "_" + square.Piece.Name;
                        SaveMove(name, move);
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
                        String move = square.Location.Row.ToString() + square.Location.Col;
                        String name = square.Piece.Side + "_" + square.Piece.Name;
                        SaveMove(name, move);
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
                        String move = square.Location.Row.ToString() + square.Location.Col;
                        String name = square.Piece.Side + "_" + square.Piece.Name;
                        SaveMove(name, move);
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
                        String move = square.Location.Row.ToString() + square.Location.Col;
                        String name = square.Piece.Side + "_" + square.Piece.Name;
                        SaveMove(name, move);
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
                        String move = square.Location.Row.ToString() + square.Location.Col;
                        String name = square.Piece.Side + "_" + square.Piece.Name;
                        SaveMove(name, move);
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
                        String move = square.Location.Row.ToString() + square.Location.Col;
                        String name = square.Piece.Side + "_" + square.Piece.Name;
                        SaveMove(name, move);
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
                        String move = square.Location.Row.ToString() + square.Location.Col;
                        String name = square.Piece.Side + "_" + square.Piece.Name;
                        SaveMove(name, move);
                    }
                    // Add Button
                    ChessBoard.Controls.Add(btn);
                    Matrix[i].Add(btn);
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
        Boolean flag = false;
        //Piece previousPiece;
        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (!flag && !isReady())
            {
                return;
            }
            else 
            {
                flag = true;
            }
            
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
                PlayTimeLine.Push(new PlayInfo(GetChessPoint(btn),CurrentPlayer));
                Mark(btn);
                ChangePlayer();

                if (playerPieceMarked != null)
                    playerPieceMarked(this, new ButtonPieceClickEvent(GetChessPoint(btn), GetChessPoint(currentPiece.Square.Button)));
                currentPiece.UpdateLocation(currentSquare);
                string move = currentSquare.Location.Row.ToString() + currentSquare.Location.Col;
                string name = currentPiece.Side + "_" + currentPiece.Name;
                SaveMove(name, move);
                //MessageBox.Show($"Move cần tìm là {move}");
                //MessageBox.Show($"currentSquare.Piece.Name là {currentSquare.Piece.Name}");
                ////string previousPiece = FindLocationPreviousPiece(move);
                //MessageBox.Show($"con cờ bị ăn là {previousPiece}");
                //EndGame(previousPiece);
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
            //int temp = 1;
            locations.ForEach(l =>
            {
                var legalSquare = squares.Find(sq => sq.Location.Row == l.Row
                && sq.Location.Col == l.Col
                && (sq.Piece == null || sq.Piece.Side != currentSquare.Piece.Side));
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
            //chốt ăn chéo
            /*if (currentPiece.Name == "P_Pawn")
            {
                locations.ForEach(l =>
                {
                    var legalSquare = squares.Find(sq => sq.Location.Row == l.Row
                    && sq.Location.Col == l.Col - 1 || (sq.Location.Row == l.Row
                    && sq.Location.Col == l.Col + 1));
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
            }*/
            
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
        void Mark(Button btn)
        {
            currentPlayer = currentPlayer == Side.Pink ? Side.Black : Side.Pink;
        }
        public void OtherPlayerMark(Point point, Point startPoint)
        {
            Button btn = Matrix[point.Y][point.X];
            Square foundSquare = squares.Find(s => s.Button.Equals(btn));
            if (foundSquare == null)
            {
                // In loi
            }
            Button startBtn = Matrix[startPoint.Y][startPoint.X];

            Square foundStartSquare = squares.Find(s => s.Button.Equals(startBtn));
            if (foundSquare == null)
            {
                // In loi
            }
            foundStartSquare.Piece.UpdateLocation(foundSquare);
            PlayTimeLine.Push(new PlayInfo(GetChessPoint(btn), currentPlayer));
            currentPlayer = currentPlayer == Side.Pink ? Side.Black : Side.Pink;
            ChangePlayer();
        }
        private Point GetChessPoint(Button btn)
        {
            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = Matrix[vertical].IndexOf(btn);
            Point point = new Point(horizontal, vertical);
            return point;
        }
        public class ButtonClickEvent : EventArgs
        {
            private Point clickedPoint;

            public Point ClickedPoint
            {
                get { return clickedPoint; }
                set { clickedPoint = value; }
            }

            public ButtonClickEvent(Point point)
            {
                this.ClickedPoint = point;
            }
        }
        public class ButtonPieceClickEvent : EventArgs
        {
            private Point clickedPoint;

            public Point ClickedPoint
            {
                get { return clickedPoint; }
                set { clickedPoint = value; }
            }

            public Point StartPoint { get; }

            public ButtonPieceClickEvent(Point point, Point startPoint)
            {
                this.ClickedPoint = point;
                StartPoint = startPoint;
            }
        }
        public bool isReady()
        {
            if (MessageBox.Show("When you choose OK, time will start! Are you ready?", "Notification", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                return true;
            }
            else
                return false;
        }
        public int index;
        void SaveMove(String name, String move)
        {
            index = dgvListMove.Rows.Add();
            dgvListMove.Rows[index].Cells[0].Value = index + 1;
            dgvListMove.Rows[index].Cells[1].Value = name.ToString();
            dgvListMove.Rows[index].Cells[2].Value = move.ToString();
        }
        private void EndGame(String name)
        {
            if (name == "Pink_King")
            {
                if(currentPlayer == Side.Black)
                    MessageBox.Show("BLACK WIN");
                else
                    MessageBox.Show("PINK WIN");
            }
            else
                return;
        }
        //private string FindLocationPreviousPiece(string location)
        //{
        //    string name = "";
        //    int i =  index-1;
        //    int a = 0;
        //    Boolean flag = false;
        //    while (i >= 0)
        //    {
        //        if (dgvListMove.Rows[i].Cells[2].Value.ToString() == location)
        //        {
        //            a++;
        //            //MessageBox.Show($"Đang chạy tới: {dgvListMove.Rows[i].Cells[1].Value.ToString()}_{dgvListMove.Rows[i].Cells[2].Value.ToString()}");
        //            //MessageBox.Show($"i = {i}");
        //            //MessageBox.Show($"index = {index}");
        //            if (a == 2)
        //            {
        //                name = dgvListMove.Rows[i].Cells[1].Value.ToString();
        //                //MessageBox.Show("Đã tìm đc");
        //                return name;
        //            }       
        //        }
        //        i--;    
        //    }
        //    return name;
        //}

        #endregion
    }
}
