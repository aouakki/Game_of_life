using System;
using System.Collections.Generic;
using System.Linq;
using SFML.Graphics;
using SFML.Window;
using DrawStrategies;
using InitStrategies;
using GUI;

namespace GameComponents
{
    class Grid
    {
        public Cell[][] Cells;
        public int Width;
        public int Height;
        public IDrawStrategy DrawStrategy{get;set;}
        public IInitStrategy InitStrategy { get; set; }
        public int ModificationsFromLast = 0;
        private List<IGridObserver> GridObservers = new List<IGridObserver>();

        public Grid( int height, int width , IDrawStrategy drawStrategy, IInitStrategy initStrategy, List<IGridObserver> observers  )
        {
            Width = width;
            Height = height;
            DrawStrategy = drawStrategy;
            InitStrategy = initStrategy;
            Cells = InitStrategy.Init(Height, Width);
            GridObservers = observers; 
        }
        public Grid(int height, int width, IDrawStrategy drawStrategy, List<IGridObserver> observers)
        {
            Width = width;
            Height = height;
            DrawStrategy = drawStrategy;
            InitStrategy = new EmptyInitStrategy();
            Cells = InitStrategy.Init(Height, Width);
            GridObservers = observers;
        }

        public void addObserver(IGridObserver window)
        {
            GridObservers.Add(window);
        }

        public void NextLevel()
        {
            Grid newGrid = this.Copy();
            newGrid =  DrawStrategy.UpdateGrid(this,newGrid);
            foreach (IGridObserver observer in GridObservers)
            {
                observer.UpdateToNextLevel(newGrid);
            }
        }


        private Grid Copy()
        {
            Grid newGrid = new Grid(Height, Width, DrawStrategy, GridObservers);
            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    bool state = this.Cells[x][y].State;
                    newGrid.Cells[x][y] = new Cell(x, y, state);

                }
            }
            newGrid.ModificationsFromLast = 0; 
            return newGrid; 
        }

        public void UpdateCell(int x, int y, bool state)
        {
            bool oldState = Cells[x][y].State; 
            if(oldState != state)
            {
                Cells[x][y].State = state;
                ModificationsFromLast = ModificationsFromLast + 1;
            }

        }
    }
}
