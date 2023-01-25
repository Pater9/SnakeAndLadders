using FluentAssertions;
using SnakeAndLadders.Library;
using SnakeAndLadders.Library.Domain;

namespace SnakeAndLadders.Tests
{
    public class GameManagerTests
    {
        private readonly GameManager _gameManager;

        public GameManagerTests()
        {
            _gameManager = new GameManager();
        }

        #region US1

        [Fact]
        public void A_player_token_can_be_added()
        {
            var player = new Player();

            _gameManager.AddPlayer(player);

            _gameManager.Players.Single().Key.Should().Be(player);
        }

        [Fact]
        public void A_newly_added_player_starts_from_starting_position()
        {
            var player = new Player();

            _gameManager.AddPlayer(player);

            _gameManager.GetPlayerPosition(player).Should().Be(GameManager.STARTING_POSITION);
        }

        [Fact]
        public void When_the_token_is_on_square_1_and_moved_3_spaces_ends_in_square_4()
        {
            var player = new Player();
            _gameManager.AddPlayer(player);

            _gameManager.MovePlayer(player, 3);

            var currentPosition = _gameManager.GetPlayerPosition(player);
            currentPosition.Should().Be(4);
        }

        [Fact]
        public void When_the_token_is_on_square_1_and_moved_3_spaces_and_then_4_ends_in_square_8()
        {
            var player = new Player();
            _gameManager.AddPlayer(player);

            _gameManager.MovePlayer(player, 3);
            _gameManager.MovePlayer(player, 4);

            var currentPosition = _gameManager.GetPlayerPosition(player);
            currentPosition.Should().Be(8);
        }

        #endregion
    }
}