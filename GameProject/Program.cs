
var backpack = new LimitedList<string>(6);
backpack.Add("Hej");

var game = new Game();
game.Run();

Console.WriteLine("Game over");
Console.ReadKey();

