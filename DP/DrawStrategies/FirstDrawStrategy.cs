using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCompenents;

namespace DrawStrategies
{
    class FirstDrawStrategy : IDrawStrategy
    {
        public Grid UpdateGrid(Grid oldGrid, Grid newGrid)
        {
           
            for (int x = 0; x < oldGrid.Height; x++)
            {
                for (int y = 0; y < oldGrid.Width; y++)
                {
                    bool state = oldGrid.Cells[x][y].State;
                    if (state)
                    {
                        int neighboorsState = oldGrid.Cells[x][y].CoundNeighboors(oldGrid);
                        if (neighboorsState <= 3)
                            newGrid.Cells[x][y].State = true;
                        else if(neighboorsState == 0 || neighboorsState==5)
                            newGrid.Cells[x][y].State = false;
                    }
                }
            }
            return newGrid;
        }

        
    }
}
