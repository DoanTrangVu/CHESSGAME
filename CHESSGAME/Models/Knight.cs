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

            return list;
        }
    }
}
