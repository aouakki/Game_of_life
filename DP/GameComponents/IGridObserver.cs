using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents
{
    interface IGridObserver
    {
         void UpdateToNextLevel(Grid grid);
    }
}
