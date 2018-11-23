using System;
using System.Collections.Generic;
using System.Linq;
using SFML.Graphics;
using SFML.Window;
using GameComponents;
using System.Threading.Tasks;
using GUI; 
namespace LifeGame
{
    class Game
    {
        public Grid Grid;
        public GUIWindow Window; 

        public Game(int height, int width)
        {
            Grid = new GridBuilder()
                .WithWidth(width)
                .WithHeight(height)
                .WithInitStrategy("First")
                .WithDrawStrategy("Second")
                .Build();
            Window = new GUIWindow(Grid);
            Grid.addObserver(Window);
        }

        public void Start()
        {
            while (Window.IsOpen())
            {
                Window.Show();
            }   
        }

    }
}
