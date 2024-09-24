using GameProject.Entities;

internal class Hero : Creature
{
    private LimitedList<Item> Backpack;

    public LimitedList<Item> BackPack { get; }
    public Hero(Cell cell) : base(cell, "H")
    {

        Color = ConsoleColor.White;
        Backpack = new LimitedList<Item>(3);
    }
}