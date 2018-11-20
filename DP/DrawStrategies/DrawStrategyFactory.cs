using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DrawStrategies
{
    class DrawStrategyFactory
    {
        public IDrawStrategy GetDrawStrategy(String strategy)
        {
            switch (strategy)
            {
                case "First":
                    return new FirstDrawStrategy();
                case "Second":
                    return new SecondDrawStrategy();
                case "Conway":
                    return new ConwayDrawStrategy();
                default:
                    return new ConwayDrawStrategy();
            }
        }
    }
}
