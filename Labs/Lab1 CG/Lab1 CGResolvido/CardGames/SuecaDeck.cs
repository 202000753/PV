using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    // Nível 5
    public class SuecaDeck : Deck
    {
        private const int AceValue = 11;
        private const int SevenValue = 10;
        private const int QueenValue = 2;
        private const int JackValue = 3;
        private const int KingValue = 4;

        public SuecaDeck()
        {
            CreateCards();
        }

        private void CreateCards()
        {
            Clear();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                if (suit == Suit.None)
                {
                    continue;
                }
                AddCard(new NumberedCard(1, suit, AceValue));
                for (int i = 2; i <= 6; i++)
                {
                    AddCard(new NumberedCard(i, suit, 0));
                }
                AddCard(new NumberedCard(7, suit, SevenValue));
                AddCard(new FaceCard(FaceName.Queen, suit, QueenValue));
                AddCard(new FaceCard(FaceName.Jack, suit, JackValue));
                AddCard(new FaceCard(FaceName.King, suit, KingValue));
            }
        }
    }
}
