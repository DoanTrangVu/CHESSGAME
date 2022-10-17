using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESSGAME.Models
{
    public class Queen : Piece
    {
        public Queen()
        {
            this.Name = "Queen";
            this.BlackImage = "B_Queen";
            this.PinkImage = "P_Queen";
        }
        public override List<Location> GetLegalLocations(Square square)
        {
            var list = new List<Location>();
            for (int i = 0; i <= 8; i++)
            {
                list.Add(new Location() { Row = i, Col = square.Location.Col });
            }
            for (int i = 0; i <= 8; i++)
            {
                list.Add(new Location() { Row = square.Location.Row, Col = (Chars)i });
            }
            int j = 1;
            while (square.Location.Row - j >= 0)
            {
                list.Add(new Location() { Row = square.Location.Row - j, Col = square.Location.Col - j});
                list.Add(new Location() { Row = square.Location.Row + j, Col = square.Location.Col + j });
                list.Add(new Location() { Row = square.Location.Row - j, Col = square.Location.Col + j });
                list.Add(new Location() { Row = square.Location.Row + j, Col = square.Location.Col - j });
                j = j + 1;
            }
            return list;
        }
    }
}
