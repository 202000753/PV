using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_CG
{
    internal class Deck
    {
        private List<Card> cards;
        private Random random = new Random();

        public Deck()
        {
            this.cards = new List<Card>();
        }

        public Deck(List<Card> c)
        {
            this.cards = new List<Card>();

            if (c != null)
            {
                foreach (Card card in c)
                {
                    this.cards.Add(card);
                }
            }
        }

        public void addCard(Card card)
        {
            if (card != null)
            {
                cards.Add(card);
            }
        }

        public bool removeCard(Card card)
        {
            return cards.Remove(card);
        }

        public void clear()
        {
            cards.Clear();
        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("Deck:\n");

            foreach (Card card in cards)
            {
                stringBuilder.Append(card + "\n");
            }

            return stringBuilder.ToString();
        }

        public Card getRandomCard()
        {
            if (cards.Count() == 0)
            {
                return null;
            }

            int randomIndex = random.Next(cards.Count() - 1);

            Card c = cards[randomIndex];
            cards.RemoveAt(randomIndex);

            return c;
        }

        public List<Card> Cards { get => cards.ToList(); }

        public Card topCard()
        {
            return cards[cards.Count - 1];
        }

        public Card drawCard()
        {
            Card c = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);

            return c;
        }

        public void putCard(Card card)
        {
            cards.Add(card);
        }

        public void sortByValue()
        {
            cards.Sort();
        }

        public void shuffle()
        {
            int n = cards.Count;

            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);

                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
    }
}
