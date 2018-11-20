using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFML;
using SFML.Graphics;
using SFML.Window;
namespace LifeGame
{
    static class Program
    {
        static void Main()
        {
            Game game = new Game(150,70);
            game.Start();

        } 
    } 
}