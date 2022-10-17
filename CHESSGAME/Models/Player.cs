using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESSGAME.Models
{
    public class Player
    {
        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private Side side;
        public Side Side
        {
            get { return side; }
            set { side = value; }
        }
        //public Image Mark
        //{
        //    get { return mark; }
        //    set { mark = value; }
        //}
        public Player(String name, Side side)
        {
            this.Name = name;
            this.Side = side;
        }
    }
}
