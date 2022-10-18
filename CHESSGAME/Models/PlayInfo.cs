using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESSGAME.Models
{
    public class PlayInfo
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
        public PlayInfo(String name)
        {
            this.Name = name;
        }
        public PlayInfo(Point point, Side side)
        {
            this.Point = point;
            this.Side = side;
            
        }
        private Point point;

        public Point Point
        {
            get { return point; }
            set { point = value; }
        }
    }
}
