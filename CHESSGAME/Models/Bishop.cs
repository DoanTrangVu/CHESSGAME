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
            
            return list;
        }
    }
}
