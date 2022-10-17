using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESSGAME.Models
{
    public class Knight : Piece
    {
        public Knight()
        {
            this.Name = "Knight";
            this.BlackImage = "B_Knight";
            this.PinkImage = "P_Knight";
        }
        public override List<Location> GetLegalLocations(Square square)
        {
            var list = new List<Location>();
            if (square.Location.Row - 1 > 0)
            {
                list.Add(new Location() { Row = square.Location.Row - 1, Col = square.Location.Col + 2 });
                list.Add(new Location() { Row = square.Location.Row - 1, Col = square.Location.Col - 2 });
            }
            if (square.Location.Row - 2 > 0)
            {
                list.Add(new Location() { Row = square.Location.Row - 2, Col = square.Location.Col + 1 });
                list.Add(new Location() { Row = square.Location.Row - 2, Col = square.Location.Col - 1 });
            }
            if (square.Location.Row + 1 < 8)
            {
                list.Add(new Location() { Row = square.Location.Row + 1, Col = square.Location.Col + 2 });
                list.Add(new Location() { Row = square.Location.Row + 1, Col = square.Location.Col - 2 });
            }
            if (square.Location.Row + 2 < 8)
            {
                list.Add(new Location() { Row = square.Location.Row + 2, Col = square.Location.Col + 1 });
                list.Add(new Location() { Row = square.Location.Row + 2, Col = square.Location.Col - 1 });
            }

            return list;
        }
    }
}
