using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESSGAME.Models
{
    public abstract class Piece
    {
        public string Name { get; set; }
        public Side Side { get; set; }
        public string BlackImage { get; set; }
        public string WhiteImage { get; set; }
        public abstract List<Location> GetLegalLocations(Square square);
        public string GetImage()
        {
            if (this.Side == Side.Black)
            {
                return this.BlackImage;
            }
            return this.WhiteImage;
        }
    }
}
