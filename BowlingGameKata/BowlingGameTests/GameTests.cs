using System.ComponentModel;
using BowlingGame;
using NUnit.Framework;

namespace BowlingGameTests
{
    public class GameTests : With_an_automocked<Game>
    {
        private void RollMany(int n, int pins)
        {
            for (var i = 0; i < n; i++)
            {
                ClassUnderTest.Roll(pins);
            }
        }

        [Test]
        public void When_game_is_on_test_gutter()
        {
            var n = 20;
            var pins = 0;
            RollMany(n, pins);
            Assert.That(0, Is.EqualTo(ClassUnderTest.Score()));
        }

        [Test]
        public void When_game_is_on_test_all_ones()
        {
            var pins = 1;
            var n = 20;
            RollMany(n, pins);
            Assert.That(20, Is.EqualTo(ClassUnderTest.Score()));
        }
        
        
    }
}