

using GameProject.Extentions;
using GameProject.UI;
using System.Data;

internal class Game
{
    private Map map = null!;
    private Hero hero = null!;

    internal void Run()
    {
        Initialize();
        Play();
    }

    private void Play()
    {
        bool gameInProgress = true;
        do
        {

       
        //DrawMap
        DrawMap();
            //GetCommand
            GetCommand();
            //Act
            //DrawMap
            //EnemyAction
            //DrawMap
        }
        while (gameInProgress);
    }

    private void GetCommand()
    {
        var keyPressed = ConsoleUI.GetKey();
        switch (keyPressed)
        {
            case ConsoleKey.LeftArrow:
                Move(Direction.West);
                break;
            case ConsoleKey.RightArrow:
                Move(Direction.East);
                break;
            case ConsoleKey.UpArrow:
                Move(Direction.North);
                break;
            case ConsoleKey.DownArrow:
                Move(Direction.South) ;
                break;
        }
    }

    private void Pickup()
    {
        if (hero.BackPack.IsFull)
        {
            Console.WriteLine("Backpack is full");
            return;
        }
        List<Item> items = hero.Cell.Items;
        Item? item = hero.Cell.Items.FirstOrDefault();

        if (item is null) return;

        if (hero.BackPack.Add(item))
        {
            Console.WriteLine($"Hero picked up {item}");
            items.Remove(item);
        }
    }
    private void Move(Position movement )
    {
        Position newPosition = hero.Cell.Position + movement;

        Cell newCell = map.GetCell(newPosition);
        if (newCell != null) hero.Cell = newCell;
        //Cell newPosition = map.GetCell(y, x);
        //if (newPosition != null) 
        //{ hero.Cell = newPosition; }
    }

    private void DrawMap()
    {
        ConsoleUI.Clear();
        ConsoleUI.Draw(map);
   
    }

    private void Initialize()
    {
        //ToDo: Read from config maybe
        map = new Map(width: 10, height: 10);
        Cell heroCell = map.GetCell(0, 0);
        hero = new Hero(heroCell);
        map.Creatures.Add(hero);

        map.GetCell(2, 4)?.Items.Add(Item.Coin());
        map.GetCell(5, 8)?.Items.Add(Item.Stone());
        map.GetCell(1, 2)?.Items.Add(Item.Stone());
        map.GetCell(7, 2)?.Items.Add(Item.Coin());
    }
}