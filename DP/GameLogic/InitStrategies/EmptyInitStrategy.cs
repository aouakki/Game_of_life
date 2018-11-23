using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameComponents;

namespace InitStrategies
{
    class EmptyInitStrategy : IInitStrategy
    {
        public Cell[][] Init(int height, int width)
        {
            Cell[][] Cells = new Cell[height][];
            for (int i = 0; i < height; i++)
                Cells[i] = new Cell[width];

            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    bool state = false;
                    Cells[x][y] = new Cell(x, y, state);

                }
            }
            return Cells;
        }
    }
}