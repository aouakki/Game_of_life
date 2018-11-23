using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameComponents;

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

            Cells[75][25] = new Cell(75, 34, true);
            Cells[75][26] = new Cell(75, 35, true);
            Cells[75][27] = new Cell(75, 36, true);
            return Cells;
        }
    }
}
