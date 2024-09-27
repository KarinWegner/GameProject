using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.GameWorld
{
    public class Cell : IDrawable
    {
        public string Symbol => ". ";
        public ConsoleColor Color { get; }
        //public int Y { get; }
        //public int X { get; }

        public Position Position { get; set; }

        public List<Item> Items { get; } = new List<Item>();
        //{
        //    get
        //    {
        //        return new List<Item>();
        //    }
        //}

        public Cell(Position position)
        {
            Color = ConsoleColor.Red;
            Position = position;
        }
    }
}
