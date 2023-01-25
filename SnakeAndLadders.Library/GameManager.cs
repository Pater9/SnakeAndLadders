using SnakeAndLadders.Library.Domain;

namespace SnakeAndLadders.Library
{
    public class GameManager
    {
        public Dictionary<Player, int> Players { get; }

        public const int STARTING_POSITION = 1;

        public GameManager()
        {
            Players = new Dictionary<Player, int>();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player, STARTING_POSITION);
        }

        public int GetPlayerPosition(Player player) => Players[player];

        public void MovePlayer(Player player, int movingPositions)
        {
            Players[player] += movingPositions;
        }
    }
}