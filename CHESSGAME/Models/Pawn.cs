using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESSGAME.Models
{
    public class Pawn : Piece
    {
        public Pawn()
        {
            GetImage();
            this.Name = "Pawn";
            this.BlackImage = "B_Pawn";
            this.PinkImage = "P_Pawn";
        }

        public override List<Location> GetLegalLocations(Square square)
        {
            var list = new List<Location>();
            if (this.Side == Side.Black)
            {
                
                if (square.Location.Row == 7)
                {
                    list.Add(new Location() { Row = square.Location.Row - 2, Col = square.Location.Col });
                    list.Add(new Location() { Row = square.Location.Row - 1, Col = square.Location.Col });
                }
                else
                    list.Add(new Location() { Row = square.Location.Row - 1, Col = square.Location.Col });
            }
            if (this.Side == Side.Pink)
            {
                
                if (square.Location.Row == 2)
                {
                    list.Add(new Location() { Row = square.Location.Row + 2, Col = square.Location.Col });
                    list.Add(new Location() { Row = square.Location.Row + 1, Col = square.Location.Col });
                }
                else
                    list.Add(new Location() { Row = square.Location.Row + 1, Col = square.Location.Col });
            }
            return list;
        }
    }
}
