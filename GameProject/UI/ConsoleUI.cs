using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameProject.UI
{
    internal class ConsoleUI
    {
        private static MessageLog<string> messageLog = new(6);

        internal static void AddMessage(string message) => messageLog.Add(message);
        //{
        //    messageLog.Add(message);
        //}
        internal static void PrintLog()
        {
            messageLog.Print(m =>Console.WriteLine(m));
        }
        internal static ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key; //intercept hindrar knapptrycket från att skrivas ut i konsollen
        internal static void Clear()
        {

            Console.CursorVisible = false;
            Console.SetCursorPosition(0,0);
        }
        internal static void Draw(Map map)
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    Cell? cell = map.GetCell( y, x);

                    IDrawable? drawable = cell;
                    ArgumentNullException.ThrowIfNull(drawable, nameof(drawable));


                    //drawable = map.Creatures.CreatureAtExtention(drawable);

                    drawable = map.Creatures.CreatureAtExtention2(cell)
                    ?? cell.Items.FirstOrDefault() as IDrawable ?? cell;

                    Console.ForegroundColor = drawable.Color;
                    Console.Write(drawable.Symbol);

                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        internal static void PrintStats(string stats)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(stats);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
