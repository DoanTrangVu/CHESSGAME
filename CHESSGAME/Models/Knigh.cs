using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESSGAME.Models
{
    public class Knigh : Piece
    {
        public Knigh()
        {
            this.Name = "Knigh";
            this.BlackImage = "B_Knigh";
            this.PinkImage = "P_Knigh";
        }
        public override List<Location> GetLegalLocations(Square square)
        {
            var list = new List<Location>();

            return list;
        }
    }
}
