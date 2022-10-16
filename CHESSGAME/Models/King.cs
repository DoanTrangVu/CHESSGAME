using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESSGAME.Models
{
    public class King : Piece
    {
        public King()
        {
            this.Name = "King";
            this.BlackImage = "B_King";
            this.PinkImage = "P_King";
        }
        public override List<Location> GetLegalLocations(Square square)
        {
            var list = new List<Location>();

            return list;
        }
    }
}
