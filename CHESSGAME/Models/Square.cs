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
        public Color Color { get; set; }
        public Button Button;
        public bool IsClick { get; set; } = false;
        public void ResetColor()
        {
            Button.BackColor = Color;
        }
        public void Select()
        {
            Button.FlatStyle = FlatStyle.Flat;
            Button.FlatAppearance.BorderSize = 1;
            Button.FlatAppearance.BorderColor = Color.Red;
        }
        public void UnSelect()
        {
            Button.FlatStyle = FlatStyle.Flat;
            Button.FlatAppearance.BorderColor = this.Color;
            Button.FlatAppearance.BorderSize = 0;
        }
        public void Disable()
        {
            Button.Enabled = false;
        }
    }
}
