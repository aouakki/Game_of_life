using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCompenents

{
    class Cell
    {
        public int X { get; }
        public int Y { get; }
        public bool State { get; set; }

        public Cell(int x, int y , bool state)
        {
            X = x;
            Y = y;
            State = state;

        }

        public int CoundNeighboors( Grid grid)
        {
            int neighboorsState = -1;
            if (!State)
                neighboorsState = 0; 

            for (int i = X - 1; i <= X + 1; i++)
            {
                for (int j = Y - 1; j <= Y + 1; j++)
                {
                    if ((i >= 0 && i < grid.Height) && (j >= 0 && j < grid.Width))
                    {
                        if (grid.Cells[i][j].State)
                            neighboorsState++;
                    }
                }
            }
            return neighboorsState;
        }
    }
}
