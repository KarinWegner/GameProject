﻿

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IConfiguration config = new ConfigurationBuilder()
                            .SetBasePath(Environment.CurrentDirectory)
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .Build();

//var ui = config.GetSection("game:ui").Value;
//var x = config.GetSection("game:mapsettings:x").Value;
//var y = config.GetSection("game:mapsettings:y").Value;

var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IConfiguration>(config);
                    services.AddSingleton<IUI, ConsoleUI>();
                    services.AddSingleton<Game>();
                })
                .UseConsoleLifetime()
                .Build();
host.Services.GetRequiredService<Game>().Run();

//var game = new Game(new ConsoleUI(), config );
//game.Run();

Console.WriteLine("Game over");
Console.ReadKey();

