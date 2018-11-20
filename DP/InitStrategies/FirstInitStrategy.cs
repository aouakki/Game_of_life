using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCompenents;

namespace InitStrategies
{

    class FirstInitStrategy : IInitStrategy
    {
        public Cell[][] Init(int height , int width)
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

            Cells[80][55] = new Cell(80, 55, true);
            Cells[80][56] = new Cell(80, 56, true);
            Cells[80][57] = new Cell(80, 57, true);
            return Cells;
        }
    }
}
