using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHESSGAME.Models
{
    public class Castle : Piece
    {
        //List<Square> squares = new List<Square>();
        public Castle()
        {
            this.Name = "Castle";
            this.BlackImage = "B_Castle";
            this.PinkImage = "P_Castle";
        }
        public override List<Location> GetLegalLocations(Square square)
        {
            var list = new List<Location>();
            for (int i = 0; i <= 8; i++)
            {
                //Boolean flag = false;
                //foreach (Location l in list)
                //{
                //    var legalSquare = squares.Find(sq => sq.Location.Row == l.Row
                //    && sq.Location.Col == l.Col);
                //    if (square.Piece != null)
                //    {
                //        flag = true;
                //        break;
                //    }
                //};
                //if (flag == true)
                //    break;
                list.Add(new Location() { Row = i, Col = square.Location.Col });
            }
            for (int i = 0; i <= 8; i++)
            {
                //Boolean flag = false;
                //foreach (Location l in list)
                //{
                    //MessageBox.Show($"({l.Row})({l.Col})");
                //    var legalSquare = squares.Find(sq => sq.Location.Row == l.Row
                //    && (Chars)i == l.Col && sq.Piece.Side == Side.Pink);
                //    MessageBox.Show($"({l.Row})({l.Col})");
                //    MessageBox.Show($"|{legalSquare}|");
                //    if (legalSquare != null)
                //    {
                //        MessageBox.Show($"|{legalSquare}| khác null");
                //        flag = true;
                //        break;
                //    }
                //    else
                //        MessageBox.Show($"|{legalSquare}| bằng null");
                //};
                //if (flag == true)
                //    break;
                list.Add(new Location() { Row = square.Location.Row, Col = (Chars)i });
            }
            return list;
        }
    }
}
