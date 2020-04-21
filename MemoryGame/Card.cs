using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryGame
{
    public class Card
    {
        public string Value;
        public int X, Y;
        public bool hasBeenDiscovered;

        public Card(string value, int x, int y)
        {
            X = x;
            Y = y;
            Value = value;
            hasBeenDiscovered = false;
        }
    }
}
