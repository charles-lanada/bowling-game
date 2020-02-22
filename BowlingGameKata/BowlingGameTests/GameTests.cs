using System.ComponentModel;
using BowlingGame;
using NUnit.Framework;

namespace BowlingGameTests
{
    public class GameTests : With_an_automocked<Game>
    {
        private void RollMany(int numberOfRoll, int pins)
        {
            for (var i = 0; i < numberOfRoll; i++)
            {
                ClassUnderTest.Roll(pins);
            }
        }

        [Test]
        public void When_game_is_on_test_gutter()
        {
            var game = ClassUnderTest;
            var numberOfRoll = 20;
            var pins = 0;
            RollMany(numberOfRoll, pins);
            Assert.That(game.Score(),  Is.EqualTo(0));
        }

        [Test]
        public void When_game_is_on_test_all_ones()
        {
            var game = ClassUnderTest;
            var pins = 1;
            var numberOfRoll = 20;
            RollMany(numberOfRoll, pins);
            Assert.That(game.Score(), Is.EqualTo(20));
        }

        [Test]
        public void When_game_is_on_test_one_spare()
        {
            var game = ClassUnderTest;
            RollSpare(game);
            game.Roll(3);
            RollMany(17, 0);
            Assert.That(game.Score(),Is.EqualTo(16));
        }

        [Test]
        public void When_game_is_on_test_one_strike()
        {
            var game = ClassUnderTest;
            RollStrike(game);
            game.Roll(3);
            game.Roll(4);
            RollMany(16,0);
            Assert.That(game.Score(), Is.EqualTo(24));
        }

        [Test]
        public void When_game_is_on_test_two_strike()
        {
            var game = ClassUnderTest;
            RollStrike(game);
            RollStrike(game);
            game.Roll(3);
            game.Roll(4);
            RollMany(14,0);
            Assert.That(game.Score(), Is.EqualTo(47));
        }

        [Test]
        public void When_game_is_on_test_two_strike_two_spare()
        {
            var game = ClassUnderTest;
            RollStrike(game);
            RollSpare(game);
            RollStrike(game);
            RollSpare(game);
            game.Roll(3);
            game.Roll(4);
            RollMany(10,0);
            Assert.That(game.Score(), Is.EqualTo(80));
        }

        [Test]
        public void When_game_is_on_test_perfect_game()
        {
            RollMany(12, 10);
            var game = ClassUnderTest;
            Assert.That(game.Score(), Is.EqualTo(300));
        }

        private static void RollStrike(Game game)
        {
            game.Roll(10);
        }

        private void RollSpare(Game game)
        {
            game.Roll(5);
            game.Roll(5);
        }
    }
}
