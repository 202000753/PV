using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    // Nível 1
    public abstract class Card : IComparable<Card>
    {
        public Suit Suit { get; set; }
        public int Value { get; set; }

        public Card()
        {
            Suit = Suit.None;
            Value = -1;
        }

        public Card(Suit suit)
        {
            Suit = suit;
        }

        public Card(Suit suit, int value)
        {
            Suit = suit;
            Value = value;
        }

        public abstract string Name { get; }


        public override string ToString()
        {
            // Nível 3 +ToNameString()
            return $"{Name} de {Suit.ToNameString()}";
        }

        // Nível 5
        public int CompareTo(Card other)
        {
            if (other is Card)
            {
                return ((Card)other).Value - Value;
            }
            return 1;
        }

    }
}
