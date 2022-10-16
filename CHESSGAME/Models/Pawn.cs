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
            this.Name = "Pawn";
        }

        public override List<Location> GetLegalLocations(Square square)
        {
            var list = new List<Location>();
            if (this.Side == Side.Black)
                list.Add(new Location() { Row = square.Location.Row - 1, Col = square.Location.Col });
            if (this.Side == Side.White)
                list.Add(new Location() { Row = square.Location.Row + 1, Col = square.Location.Col });
            return list;
        }
    }
}
