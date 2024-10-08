﻿
using System.Diagnostics;
namespace GameProject.GameWorld
{
    public class Map : IMap
    {
        private Cell[,] cells;
        public int Width { get; }
        public int Height { get; }

        public List<Creature> Creatures { get; } = new List<Creature>();

        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            cells = new Cell[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[y, x] = new Cell(new Position(y, x));
                }

            }
        }

        public Cell? GetCell(int y, int x)
        {
            return (x < 0 || x >= Width || y < 0 || y >= Height) ? null : cells[y, x];
        }
        public Cell? GetCell(Position newPosition)
        {
            return GetCell(newPosition.Y, newPosition.X);
        }

        public void Place(Creature creature)
        {
            if (Creatures.FirstOrDefault(c => c.Cell == creature.Cell) == null)
                Creatures.Add(creature);
        }

        public Creature? CreatureAt(Cell cell)
        {
            return Creatures.FirstOrDefault(c => c.Cell == cell);
        }
    }
}