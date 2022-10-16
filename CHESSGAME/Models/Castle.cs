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
            this.BlackImage = "B_Castle";
            this.PinkImage = "P_Castle";
        }
        public override List<Location> GetLegalLocations(Square square)
        {
            var list = new List<Location>();
            for (int i = 0; i <= 8; i++)
                list.Add(new Location() { Row = i, Col = square.Location.Col });
            for (int i = 0; i <= 8; i++)
                list.Add(new Location() { Row = square.Location.Row, Col = (Chars)i });
            return list;
        }
    }
}
