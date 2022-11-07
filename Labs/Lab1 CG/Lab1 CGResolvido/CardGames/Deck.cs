using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    // Nível 4
    public class Deck
    {
        private List<Card> cards;
        private Random random = new Random();

        public Deck()
        {
            cards = new List<Card>();
        }

        public Deck(List<Card> cards)
        {
            this.cards = new List<Card>();
            if (cards != null)
            {
                foreach (Card card in cards)
                {
                    this.cards.Add(card);
                }
            }
        }

        public void AddCard(Card card)
        {
            if (card != null)
            {
                cards.Add(card);
            }
        }

        public bool RemoveCard(Card card)
        {
            return cards.Remove(card);
        }

        public void Clear()
        {
            cards.Clear();
        }


        public Card TopCard()
        {
            if (cards.Count == 0)
                return null;

            return cards[cards.Count - 1];
        }

        public Card DrawCard()
        {
            if (cards.Count == 0)
                return null;

            Card card = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return card;
        }

        public void PutCard(Card card)
        {
            cards.Add(card);
        }

        public Card GetRandomCard()
        {
            if (cards.Count == 0)
            {
                return null;
            }

            int randomIndex = random.Next(cards.Count - 1);
            Card card = cards[randomIndex];
            cards.RemoveAt(randomIndex);
            return card;
        }


        public List<Card> Cards
        {
            get
            {
                return new List<Card>(cards);
            }

        }


        public override string ToString()
        {
            StringBuilder cardsList = new StringBuilder();


            foreach (Card card in cards)
            {
                cardsList.Append(card + "\n");
            }

            return cardsList.ToString();
        }

        // Nível 5
        public void SortByValue()
        {
            cards.Sort();
        }


        public void Shuffle()
        {
            int count = cards.Count;
            while (count > 1)
            {
                count--;
                int k = random.Next(count + 1);
                Card value = cards[k];
                cards[k] = cards[count];
                cards[count] = value;
            }
        }

        // Desafio
        public void Sort()
        {
            cards.Sort(new CardSuitValueComparer());
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return cards.GetEnumerator();
        }

    }
}
