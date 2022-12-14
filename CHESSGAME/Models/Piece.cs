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
        public Square Square { get; set; }
        public Side Side { get; set; }
        public string BlackImage { get; set; }
        public string PinkImage { get; set; }
        public abstract List<Location> GetLegalLocations(Square square);
        public string GetImage()
        {
            if (this.Side == Side.Black)
            {
                return this.BlackImage;
            }
            return this.PinkImage;
        }
        public void UpdateLocation(Square newSquare)
        {
            newSquare.ResetColor();

            newSquare.Button.BackgroundImage = this.Square.Button.BackgroundImage;
            this.Square.Button.BackgroundImage = null;

            newSquare.Piece = this;

            this.Square.UnSelect();
            this.Square.Piece = null;

            this.Square = newSquare;
        }
    }
}
