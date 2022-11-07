using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    public class CardSuitValueComparer : Comparer<Card>
    {
        public override int Compare(Card card1, Card card2)
        {
            if (card1.Suit != card2.Suit)
            {
                return (int)card1.Suit - (int)card2.Suit;
            }
            if (card1 is FaceCard && card2 is FaceCard)
            {
                return (int)((FaceCard)card1).FaceName
                       - (int)((FaceCard)card2).FaceName;
            }
            if (card1 is FaceCard)
            {
                return 1;
            }
            if (card2 is FaceCard)
            {
                return -1;
            }
            if (card1 is NumberedCard && card2 is NumberedCard)
            {
                return ((NumberedCard)card1).Number
                       - ((NumberedCard)card2).Number;
            }
            return -1;
        }
    }
}
