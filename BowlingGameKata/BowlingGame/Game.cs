using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace BowlingGame
{
    public class Game
    {
        private int CurrentRole;
        private readonly int[] Rolls = new int[21];

        public void Roll(int pins)
        {
            Rolls[CurrentRole] = pins;
            CurrentRole++;
        }

        public int Score()
        {
            var score = 0;
            var frameIndex = 0;
            for (var frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += StrikeBonus(frameIndex);
                    frameIndex += 1;
                }
                else if (IsSpare(frameIndex))
                {
                    score += SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }

                Console.WriteLine($"frame # {frame + 1}: {score}");
            }

            return score;
        }

        private bool IsStrike(int frameChanceIndex)
        {
            return Rolls[frameChanceIndex] == 10;
        }

        private int SumOfBallsInFrame(int frameChanceIndex)
        {
            return Rolls[frameChanceIndex] + Rolls[frameChanceIndex + 1];
        }

        private int SpareBonus(int frameChanceIndex)
        {
            return 10 + Rolls[frameChanceIndex + 2];
        }

        private int StrikeBonus(int frameChanceIndex)
        {
            return 10 + Rolls[frameChanceIndex + 1] + Rolls[frameChanceIndex + 2];
        }

        bool IsSpare(int i)
        {
            return Rolls[i] + Rolls[i + 1] == 10;
        }
    }
}
