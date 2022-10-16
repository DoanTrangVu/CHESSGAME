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

            return list;
        }
    }
}
