using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    // Nível 2
    public class NumberedCard : Card
    {
        private int number;  // número da carta (1 a 10)

        public NumberedCard()
        {

        }
        public NumberedCard(int number, Suit suit) : base(suit)
        {
            this.number = number;
        }

        public NumberedCard(int number, Suit suit, int value) : base(suit, value)
        {
            this.number = number;
        }

        public int Number => number;

        public override string Name
        {
            get
            {
                switch (number)
                {
                    case 1:
                        return "ás";
                    case 2:
                        return "dois";
                    case 3:
                        return "três";
                    case 4:
                        return "quatro";
                    case 5:
                        return "cinco";
                    case 6:
                        return "seis";
                    case 7:
                        return "sete";
                    case 8:
                        return "oito";
                    case 9:
                        return "nove";
                    case 10:
                        return "dez";
                    default:
                        return "";
                }
            }
        }
    }
}
