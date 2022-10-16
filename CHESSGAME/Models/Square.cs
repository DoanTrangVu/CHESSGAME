using System;
using System.Collections.Generic;
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

        public Button Button;
    }
}
