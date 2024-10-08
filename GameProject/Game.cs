﻿

using GameProject.Extentions;
using GameProject.UI;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Runtime.InteropServices;

internal class Game
{
    private Dictionary<ConsoleKey, Action> actionMenu = null!;
    private IMap map;
    private Hero hero = null!;
    private bool gameInProgress;
    private readonly IUI ui;
    private readonly IConfiguration config;

    //private ConsoleUI ui = new ConsoleUI();

    public Game(IUI ui, IConfiguration config)
    {
        this.ui = ui;
        this.config = config;
        //this.map = map;
    }
    internal void Run()
    {
        Initialize();
        Play();
    }

    private void Play()
    {
        gameInProgress = true;
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
        var keyPressed = ui.GetKey();
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
                Move(Direction.South);
                break;


        }
        if (actionMenu.ContainsKey(keyPressed))
            actionMenu[keyPressed]?.Invoke();
    }

    private void Inventory()
    {
        ui.AddMessage(hero.BackPack.Count > 0 ? "Inventory:" : "No items");
        for (int i = 0; i < hero.BackPack.Count; i++)
        {
            ui.AddMessage($"{i + 1}: {hero.BackPack[i]}");
        }
    }

    private void PickUp()
    {
        if (hero.BackPack.IsFull)
        {
            ui.AddMessage("Backpack is full");
            return;
        }
        List<Item> items = hero.Cell.Items;
        Item? item = hero.Cell.Items.FirstOrDefault();

        if (item is null) return;

        if(item is IUseable healthPotion)
        {
            healthPotion.Use(hero, c=>c.Health +=30);
            hero.Cell.Items.Remove(item);
            ui.AddMessage($"Hero used the {item}");
            return;
        }

        if (hero.BackPack.Add(item))
        {
            ui.AddMessage($"Hero picked up {item}");
            items.Remove(item);
        }
    }
    private void Move(Position movement)
    {
        Position newPosition = hero.Cell.Position + movement;

        Cell newCell = map.GetCell(newPosition);

        Creature? opponent = map.CreatureAt(newCell!);

        if(opponent is not null)
        {
            hero.Attack(opponent);
            opponent.Attack(hero);
        }

        gameInProgress = !hero.IsDead;

        if (newCell is not null)
        {
            hero.Cell = newCell;

            if (newCell.Items.Any())
                ui.AddMessage($"You see {string.Join(",", newCell.Items)}");
        }

    }
    private void Drop()
    {

        var item = hero.BackPack.FirstOrDefault();

        if (item is not null && hero.BackPack.Remove(item))
        {
            hero.Cell.Items.Add(item);
            ui.AddMessage($"Hero dropped the {item}");
        }
        else
        {
            ui.AddMessage("BackPack is empty");
        }
    }

    private void DrawMap()
    {
        ui.Clear();
        ui.Draw(map);
        ui.PrintStats($"Hero's Health: {hero.Health},\tEnemies: {map.Creatures.Where(c => !c.IsDead).Count() - 1}");
        ui.PrintLog();

    }

    private void Initialize()
    {
        actionMenu = new Dictionary<ConsoleKey, Action>
        {
           { ConsoleKey.P, PickUp},
           { ConsoleKey.I, Inventory },
            {ConsoleKey.D, Drop }
         };

        var r = new Random();

        var width = config.GetMapSizeFor("x");
        var height = config.GetMapSizeFor("y");

        map = new Map(height, width);


      //  map = new Map(width: 10, height: 10);
        Cell heroCell = map.GetCell(0, 0);
        hero = new Hero(heroCell);
        map.Creatures.Add(hero);

        map.GetCell(2, 2)!.Items.Add(Item.Coin());
        RCell().Items.Add(Item.Coin());
        map.GetCell(5, 8)?.Items.Add(Item.Stone());
        map.GetCell(1, 2)?.Items.Add(Item.Stone());
        map.GetCell(7, 2)?.Items.Add(Item.Coin());
        RCell().Items.Add(Potion.HealthPotion());
        RCell().Items.Add(Potion.HealthPotion());
        RCell().Items.Add(Potion.HealthPotion());

        map.Place(new Orc(RCell()));
        map.Place(new Orc(RCell()));
        map.Place(new Troll(RCell()));

        map.Creatures.ForEach(c =>
        {
            c.AddToLog = ui.AddMessage;
        });

        Cell RCell()
        {
            var width = r.Next(0, map.Width);
            var height = r.Next(0, map.Height);

            var cell = map.GetCell(height, width);
            ArgumentNullException.ThrowIfNull(cell, nameof(cell));

            return cell;
        }
    }
}