using System;
using System.Collections.Generic;
using System.Linq;
using SFML.Graphics;
using SFML.Window;
using GameCompenents;
using System.Threading.Tasks;

namespace GUI
{
 


    class GUIWindow : IGridObserver
    {
        public RenderWindow GUI { get; }
        public BackgroundFacade BcgManager = new BackgroundFacade();
        public Sprite Background; 
        public int TimeBtwFrames = 500;
        public bool stop = false;
        public event EventHandler UserEntryStop;
        public Sprite Bcg { get; set; }
        public Grid Grid;

        public GUIWindow(Grid grid)
        {
            Grid = grid; 
            Background = BcgManager.CreateBackground(grid);
            int Height = grid.Height * BcgManager.cell_dimension;
            int Width = grid.Width * BcgManager.cell_dimension;
            GUI = new RenderWindow(new VideoMode((uint)(Height), (uint)(Width)), "Jeux de vie");
        }

        /// events 
        private void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.Space:
                    stop = !stop;
                    break;
            }
        }

        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }


        public bool IsOpen()
        {
            return GUI.IsOpen(); 
        }
       
        
        public void Show()
        {
            GUI.DispatchEvents();
            GUI.KeyPressed += Window_KeyPressed;
            GUI.Closed += new EventHandler(OnClose);
            if (!stop)
            {
                Grid.NextLevel();
                GUI.Clear();
                Render(Grid);
                GUI.Display();
            }
        }

        private void Render(Grid grid)
        {
            
                if (grid.ModificationsFromLast != 0)
                {
                    System.Threading.Thread.Sleep(TimeBtwFrames / 10);
                    Background = BcgManager.CreateBackground(grid);
                    GUI.Draw(Background);

                }
       
        }

        public void UpdateToNextLevel(Grid grid)
        {
            Grid = grid;
        }
    }
}
