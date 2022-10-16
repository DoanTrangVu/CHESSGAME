using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHESSGAME.Models
{
    public class Square
    {
        public Location Location { get; set; }
        public Piece Piece { get; internal set; }
        public int FlagPiece { get; set; }
        public Color Color { get; set; }
        public Button Button;
        public void ResetColor()
        {
            Button.BackColor = Color;
            Button.FlatStyle = FlatStyle.Flat;
            Button.FlatAppearance.BorderColor = this.Color;
            Button.FlatAppearance.BorderSize = 0;
        }
    }
}
