using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameComponents;

namespace InitStrategies
{
    interface IInitStrategy
    {
         Cell[][] Init(int height, int width);
    }
}
