using System;

namespace PPT_monopoly
{
    class Dice
    {
        private readonly Random _rnd;
        private readonly int _sides;

        public Dice(int sides)
        {
            _sides = sides;
            _rnd = new Random();
        }

        public int Roll()
        {
            return _rnd.Next(1, _sides + 1);
        }
    }
}
