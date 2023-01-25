
using Microsoft.Extensions.DependencyInjection;
using SnakeAndLadders.Library;

Console.WriteLine("Welcome to snake and ladders!");

var serviceCollection = new ServiceCollection();
serviceCollection
    .AddSnakeAndLaddersServices();

var serviceProvider = serviceCollection.BuildServiceProvider();

var gameManager = serviceProvider.GetRequiredService<GameManager>();

var player = gameManager.AddPlayer();
var position = gameManager.GetPlayerPosition(player);

Console.WriteLine($"Player starts at position {position}");

while (true)
{
    var diceRoll = gameManager.RollADie(player);
    position = gameManager.GetPlayerPosition(player);
    Console.WriteLine($"Player [{player.Name}] rolled a {diceRoll} and advanced to position {position}");

    await Task.Delay(500);

    if (gameManager.PlayerHasWon(player))
    {
        Console.WriteLine($"Player has won the game!");
        break;
    }
}

Console.ReadLine();