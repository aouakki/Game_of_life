using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameComponents;

namespace InitStrategies
{
    class FileInitStrategy : IInitStrategy
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

            string path = @"..\..\..\Examples\inits\glidergun.txt";
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                int i = 0;
                while ((s = sr.ReadLine()) != null && i < height)
                {
                    for (int j = 0; j < width && j < s.Length; j++)
                    {
                        if (s[j] == 'X')
                            Cells[i][j].State = true;
                    }
                    i++;
                }
            }

            return Cells;
        }
    }
}