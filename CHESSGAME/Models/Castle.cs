using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESSGAME.Models
{
    public class Castle : Piece
    {
        public Castle()
        {
            this.Name = "Castle";
            // Set Black and White image
            this.BlackImage = "BlackCastle.png";
            this.WhiteImage = "WhiteCatsle.png";
        }
        public override List<Location> GetLegalLocations(Square square)
        {
            var list = new List<Location>();
            // Update !!!!
            if (this.Side == Side.Black)
                list.Add(new Location() { Row = square.Location.Row - 1, Col = square.Location.Col });
            if (this.Side == Side.White)
                list.Add(new Location() { Row = square.Location.Row + 1, Col = square.Location.Col });
            return list;
        }
    }
}
