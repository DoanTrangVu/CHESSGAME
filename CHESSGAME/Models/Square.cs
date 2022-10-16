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
        public int Row { get; set; }
        public Chars Col { get; set; }
        public string PieceName { get; set; }
        public Button Button;
    }
}
