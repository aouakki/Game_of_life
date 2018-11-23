using System;
using System.Collections.Generic;
using System.Linq;
using SFML.Graphics;
using SFML.Window;
using GameComponents;
using System.Threading.Tasks;

namespace GUI
{
    class  BackgroundFacade
    {
        Color onColor = new Color(0x52, 0x00, 0x52);
        Color offColor = new Color(0x62, 0x94, 0xe0);
        Color borderColor = new Color(0x00, 0x00, 0x00);
        public int cell_dimension = 10;

        public BackgroundFacade()
        {
        }

        private  Image DrawCell(Image image, Cell cell)
        {
            int x = cell.X;
            int y = cell.Y;
            bool state = cell.State;
            Color color = offColor;
            int xi_max = x * cell_dimension + cell_dimension;
            int yi_max = y * cell_dimension + cell_dimension;
            for (int xi = x * cell_dimension; xi < xi_max; xi++)
            {
                for (int yi = y * cell_dimension; yi < yi_max; yi++)
                {
                    if (state)
                        color = onColor;
                    else
                        color = offColor;


                    image.SetPixel((uint)xi, (uint)yi, color);

                    //draw border 
                    if (xi == x * cell_dimension || yi == y * cell_dimension)
                        image.SetPixel((uint)xi, (uint)yi, borderColor);

                }


            }
            return image;
        }


        public Sprite CreateBackground(Grid grid)
        {
            int Height = grid.Height * cell_dimension;
            int Width = grid.Width * cell_dimension;
            Image image = new Image((uint)Height, (uint)Width);

            for (int x = 0; x < grid.Height; x++)
            {
                for (int y = 0; y < grid.Width; y++)
                {

                    image = DrawCell(image, grid.Cells[x][y]);
                }
            }
            Sprite sprite = new Sprite(new Texture(image))
            {
                Position = new Vector2f(0, 0)
            };
            return sprite;
        }
    }
}
