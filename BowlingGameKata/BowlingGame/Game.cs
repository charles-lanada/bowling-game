using System;
using System.Drawing;

namespace BowlingGame
{
    public class Game
    {
        public void Roll(int pins)
        {
            score += pins;
        }

        private int score { get; set; }

        public int Score()
        {
            return score;
        }
    }
}