﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_CG
{
    internal abstract class Card
    {
        public Suit suit { get; set; }
        public int value { get; set; }

        public Card(Suit s, int v)
        {
            suit = s;
            value = v;
        }

        public Card(Suit s)
        {
            suit = s;
        }

        public Card()
        {
            suit = Suit.None;
            value = -1;
        }

        public abstract string Name { get; }

        public Suit Suit { get => suit; }
    }
}
