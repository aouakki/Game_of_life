using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitStrategies; 
namespace DrawStrategies
{
    class InitStrategyFactory
    {
        public IInitStrategy GetInitStrategy(String strategy)
        {
            switch (strategy)
            {
                case "First":
                    return new FirstInitStrategy();
                default:
                    return new FirstInitStrategy();
            }
        }
    }
}
