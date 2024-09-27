

using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
                            .SetBasePath(Environment.CurrentDirectory)
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .Build();

//var ui = config.GetSection("game:ui").Value;
//var x = config.GetSection("game:mapsettings:x").Value;
//var y = config.GetSection("game:mapsettings:y").Value;

var width = config.GetMapSizeFor("x");
var height = config.GetMapSizeFor("y");

var map = new Map(height, width);
var game = new Game(new ConsoleUI(), map );
game.Run();

Console.WriteLine("Game over");
Console.ReadKey();

