using GameCompenents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitStrategies;
using DrawStrategies;
namespace GameCompenents
{
    class GridBuilder
    {
        public int Width;
        public int Height;
        public IDrawStrategy DrawStrategy { get; set; }
        public IInitStrategy InitStrategy { get; set; }

       
        public GridBuilder WithInitStrategy(String initStrategy)
        {
            InitStrategy = new InitStrategyFactory().GetInitStrategy(initStrategy);
            return this; 

        }

        public GridBuilder WithDrawStrategy(String  drawStrategy)
        {
            DrawStrategy = new  DrawStrategyFactory().GetDrawStrategy(drawStrategy);
            return this; 
        }

        public GridBuilder WithWidth(int width)
        {
            Width = width;
            return this;

        }
        public GridBuilder WithHeight(int height)
        {
            Height = height;
            return this;
        }

        public Grid Build()
        {
            return new Grid(Height, Width, DrawStrategy, InitStrategy);
        }
    }
}
