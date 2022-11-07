using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    // Nível 3
    public static class CardUtils
    {
        public static string ToNameString(this FaceName faceName)
        {
            switch (faceName)
            {
                case FaceName.Jack:
                    return "valete";
                case FaceName.Queen:
                    return "dama";
                case FaceName.King:
                    return "rei";
                default:
                    return "";
            }

        }

        public static string ToNameString(this Suit suit)
        {
            switch (suit)
            {
                case Suit.Spades:
                    return "espadas";
                case Suit.Hearts:
                    return "copas";
                case Suit.Diamonds:
                    return "ouros";
                case Suit.Clubs:
                    return "paus";
                default:
                    return "";
            }

        }
    }
}
