using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_CG
{
    internal static class CardUtils
    {
        //FaceName e Suit

        public static string ToNameString(this FaceName fN)
        {
            switch (fN)
            {
                case FaceName.Valete:
                    return "Valete";
                case FaceName.Rainha:
                    return "Rainha";
                case FaceName.Rei:
                    return "Rei";
                default:
                    return "";
            }
        }

        public static string ToNameString(this Suit s)
        {
            switch (s)
            {
                case Suit.None:
                    return "None";
                case Suit.Espadas:
                    return "Espadas";
                case Suit.Paus:
                    return "Paus";
                case Suit.Ouros:
                    return "Ouros";
                case Suit.Copas:
                    return "Copas";
                default:
                    return "";
            }
        }
    }
}
