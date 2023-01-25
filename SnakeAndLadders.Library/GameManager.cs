using SnakeAndLadders.Library.Domain;

namespace SnakeAndLadders.Library
{
    public class GameManager
    {
        public Dictionary<Player, int> Players { get; }

        public const int STARTING_POSITION = 1;

        public int BoardLength { get; } = 100;

        private readonly IDiceThrower _diceThrower;

        public GameManager(IDiceThrower diceThrower)
        {
            Players = new Dictionary<Player, int>();

            _diceThrower = diceThrower;
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player, STARTING_POSITION);
        }

        public int GetPlayerPosition(Player player) => Players[player];

        public void MovePlayer(Player player, int movingPositions)
        {
            var currentPosition = Players[player];

            if (currentPosition + movingPositions > BoardLength)
            {
                return;
            }

            Players[player] += movingPositions;
        }

        public bool PlayerHasWon(Player player)
        {
            return Players[player] == BoardLength;
        }

        public int RollADie(Player player)
        {
            var rolledValue = _diceThrower.Roll();

            MovePlayer(player, rolledValue);

            return rolledValue;
        }
    }
}