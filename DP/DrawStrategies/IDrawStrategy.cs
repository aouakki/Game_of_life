
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DP;
using GameCompenents;

namespace DrawStrategies 
{
    interface IDrawStrategy
    {
         Grid UpdateGrid(Grid oldGrid, Grid newGrid);
    }
}
