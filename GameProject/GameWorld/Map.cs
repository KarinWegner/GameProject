
using System.Diagnostics;

internal class Map
{
    private Cell[,] cells;
    public int Width { get; }
    public int Height { get; }

    public List<Creature> Creatures{get;}

    public Map(int width, int height)
    {
        Width = width;
        Height = height;

        cells = new Cell[width, height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                cells[x, y] = new Cell();
            }

        }
    }

    //ToDo: Do better
    internal Cell? GetCell(int y, int x)
    {
        return (x < 0 || x >= Width || y < 0 || y >= Height) ? null : cells[y, x];
    }
}