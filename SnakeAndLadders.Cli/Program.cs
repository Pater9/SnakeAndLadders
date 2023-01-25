
using Microsoft.Extensions.DependencyInjection;
using SnakeAndLadders.Library;
using SnakeAndLadders.Library.Domain;

Console.WriteLine("Welcome to snake and ladders!");


var serviceCollection = new ServiceCollection();
serviceCollection
    .AddSnakeAndLaddersServices();

var serviceProvider = serviceCollection.BuildServiceProvider();

var gameManager = serviceProvider.GetRequiredService<GameManager>();

var player = new Player();

gameManager.AddPlayer(player);

var position = gameManager.GetPlayerPosition(player);

Console.WriteLine($"Player starts at position {position}");

while (true)
{
    var diceRoll = gameManager.RollADie(player);
    position = gameManager.GetPlayerPosition(player);
    Console.WriteLine($"Player rolled a {diceRoll} and advanced to position {position}");

    await Task.Delay(500);

    if (gameManager.PlayerHasWon(player))
    {
        Console.WriteLine($"Player has won the game!");
        break;
    }
}

Console.ReadLine();