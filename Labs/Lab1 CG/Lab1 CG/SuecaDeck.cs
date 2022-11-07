using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_CG
{
    internal class SuecaDeck : Deck
    {
        private const int ACE_VALUE = 11;
        private const int SEVEN_VALUE = 10;
        private const int QUEEN_VALUE = 2;
        private const int JACK_VALUE = 3;
        private const int KING_VALUE = 4;

        public SuecaDeck()
        {
            createCards();
        }

        private void createCards()
        {
            clear();

            foreach (Suit suit in (Suit[])Enum.GetValues(typeof(Suit)))
            {
                if (suit == Suit.None)
                {
                    continue;
                }

                addCard(new NumberedCard(1, suit, ACE_VALUE));

                for (int i = 2; i <= 6; i++)
                {
                    addCard(new NumberedCard(i, suit, 0));
                }

                addCard(new NumberedCard(7, suit, SEVEN_VALUE));
                addCard(new FaceCard(FaceName.Rainha, suit, QUEEN_VALUE));
                addCard(new FaceCard(FaceName.Valete, suit, JACK_VALUE));
                addCard(new FaceCard(FaceName.Rei, suit, KING_VALUE));
            }
        }
    }
}
