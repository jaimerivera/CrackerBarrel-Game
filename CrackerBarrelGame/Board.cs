using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackerBarrelGame
{
    class Board
    {
        int[] positions;

        public Board()
        {
            positions  = new int[15];
        }

        public int[] Positions
        {
            get { return positions; }
            set { positions = value; }
        }
    }

    struct Move
    {
       public int from;
       public int to;
       public int remove;
    }
}
