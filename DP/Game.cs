using System;
using System.Collections.Generic;
using System.Linq;
using SFML.Graphics;
using SFML.Window;
using GameCompenents;
using System.Threading.Tasks;

namespace LifeGame
{
    class Game
    {
        public RenderWindow Window { get; }
        public Sprite Background { get; set; }
        public int cell_dimension = 10;
        public int Height, Width;
        public Grid grid;
        Color onColor = new Color(0x52, 0x00, 0x52);
        Color offColor = new Color(0xFF, 0xFF, 0xFF);
        Color borderColor = new Color(0x00, 0x00, 0x00);
        public long LastTime = 0;
        public long TimeBtwFrames = 500; 


        public Game(int height, int width)
        {
            Height = height * cell_dimension;
            Width = width * cell_dimension;
            Window = new RenderWindow(new VideoMode((uint)(Height), (uint)(Width)), "Jeux de vie");
            grid = new GridBuilder()
                .WithWidth(width)
                .WithHeight(height)
                .WithInitStrategy("First")
                .WithDrawStrategy("Conway")
                .Build();
            Background = createSprite(grid);
            LastTime = GetCurrentTime(); 

        }
        private long GetCurrentTime()
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }


        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }


        private Image DrawCell(Image image, Cell cell)
        {
            int x = cell.X;
            int y = cell.Y;
            bool state = cell.State;
            Color color = offColor;
            int xi_max = x * cell_dimension + cell_dimension;
            int yi_max = y * cell_dimension + cell_dimension; 
            for (int xi = x * cell_dimension; xi < xi_max; xi++)
            {
                for (int yi = y * cell_dimension; yi <yi_max ; yi++)
                {
                    if (state)
                        color = onColor;
                    else
                        color = offColor;
                   
                    if (!(xi > 1499 || yi > 699))
                    {
                        image.SetPixel((uint)xi, (uint)yi, color);

                        //draw border 
                        if (xi == x * cell_dimension || yi == y * cell_dimension)
                            image.SetPixel((uint)xi, (uint)yi, borderColor);
                    }
                }
                

            }
            return image;
        }


        private void updateSprite()
        {
            grid = grid.NextLevel();
            Background = createSprite(grid); 
        }
         

        private Sprite createSprite(Grid grid)
        {
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

       


        private void Render()
        {
            Window.Closed += new EventHandler(OnClose);
            Window.Clear();
            Window.Draw(Background);
            Window.Display();
        }

        public void Start()
        {
            while (Window.IsOpen())
            {
                if(GetCurrentTime()-LastTime > TimeBtwFrames)
                {
                    updateSprite();
                }
                Window.DispatchEvents();
                Render();
            }
        }

    }
}
