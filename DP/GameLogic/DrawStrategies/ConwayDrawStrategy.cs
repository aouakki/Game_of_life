using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameComponents;

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
                            newGrid.UpdateCell(x, y, false);

                        else if (neighboorsState == 2 || neighboorsState == 3)
                            newGrid.UpdateCell(x, y, true);
                    }
                    else
                    {
                        if (neighboorsState == 3)
                            newGrid.UpdateCell(x, y, true);
                    }
             
                        
                }
            }
            return newGrid;

        }
    }
}
