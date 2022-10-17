using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESSGAME.Models
{
    public class Bishop : Piece
    {
        public Bishop()
        {
            this.Name = "Bishop";
            this.BlackImage = "B_Bishop";
            this.PinkImage = "P_Bishop";
        }
        public override List<Location> GetLegalLocations(Square square)
        {
            var list = new List<Location>();
            int j = 1;
            while (square.Location.Row - j >= -1)
            {
                list.Add(new Location() { Row = square.Location.Row - j, Col = square.Location.Col - j });
                list.Add(new Location() { Row = square.Location.Row + j, Col = square.Location.Col - j });
                list.Add(new Location() { Row = square.Location.Row + j, Col = square.Location.Col + j });
                list.Add(new Location() { Row = square.Location.Row - j, Col = square.Location.Col + j });
                j = j + 1;
            }
            j = 1;
            while (square.Location.Row + j <= 9)
            {
                list.Add(new Location() { Row = square.Location.Row - j, Col = square.Location.Col - j });
                list.Add(new Location() { Row = square.Location.Row + j, Col = square.Location.Col - j });
                list.Add(new Location() { Row = square.Location.Row + j, Col = square.Location.Col + j });
                list.Add(new Location() { Row = square.Location.Row - j, Col = square.Location.Col + j });
                j = j + 1;
            }
            return list;
        }
    }
}
