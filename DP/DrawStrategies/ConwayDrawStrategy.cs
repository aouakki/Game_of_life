using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCompenents;

namespace DrawStrategies
{
    class ConwayDrawStrategy : IDrawStrategy
    {
        public Grid UpdateGrid(Grid oldGrid, Grid newGrid)
        {
            for (int x = 0; x < oldGrid.Height; x++)
            {
                for (int y = 0; y < oldGrid.Width; y++)
                {
                    bool state = oldGrid.Cells[x][y].State;
                    int neighboorsState = oldGrid.Cells[x][y].CoundNeighboors(oldGrid);

                    if (state)
                    {
                        if (neighboorsState < 2 || neighboorsState > 3)
                            newGrid.Cells[x][y].State = false;
                            

                        if (neighboorsState == 2 || neighboorsState == 3)
                            newGrid.Cells[x][y].State = true;
                    }
                    else
                    {
                        if (neighboorsState == 3)
                            newGrid.Cells[x][y].State = true;
                    }
             
                        
                }
            }
            return newGrid;

        }
    }
}
