﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESSGAME.Models
{
    public class Castle : Piece
    {
        public Castle()
        {
            this.Name = "Castle";
            this.BlackImage = "B_Castle";
            this.PinkImage = "P_Castle";
        }
        public override List<Location> GetLegalLocations(Square square)
        {
            var list = new List<Location>();

            return list;
        }
    }
}
