using System;
using System.Collections.Generic;
using System.Linq;
using SFML.Graphics;
using SFML.Window;
using DrawStrategies;
using InitStrategies;

namespace GameCompenents
{
    class Grid
    {
        public Cell[][] Cells;
        public int Width;
        public int Height;
        public IDrawStrategy DrawStrategy{get;set;}
        public IInitStrategy InitStrategy { get; set; }

        public Grid( int height, int width )
        {
            Width = width;
            Height = height;
            DrawStrategy = new ConwayDrawStrategy();
            InitStrategy = new FirstInitStrategy();
            Cells = InitStrategy.Init(Height, Width);

        }

        

        public Grid NextLevel()
        {
            Grid newGrid = this.Copy();
            return DrawStrategy.UpdateGrid(this,newGrid);
        }

        private Grid Copy()
        {
            Grid newGrid = new Grid(Height, Width);
            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    bool state = this.Cells[x][y].State;
                    newGrid.Cells[x][y] = new Cell(x, y, state);

                }
            }

            return newGrid; 
        }
    }
}
