using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_CG
{
    internal class NumberedCard : Card
    {
        public int number { get; set; }

        public NumberedCard(int n, Suit s) : base(s)
        {
            number = n;
        }

        public NumberedCard(int n, Suit s, int v) : base(s, v)
        {
            number = n;
        }

        public NumberedCard()
        {

        }

        public int Number { get => number; }

        public override string Name
        {
            get
            {
                switch (number)
                {
                    case 1: 
                        return "Ás";
                    case 2:
                        return "Dois";
                    case 3:
                        return "Três";
                    case 4:
                        return "Quatro";
                    case 5:
                        return "Cinco";
                    case 6:
                        return "Seis";
                    case 7:
                        return "Sete";
                    case 8:
                        return "Oito";
                    case 9:
                        return "Nove";
                    case 10:
                        return "Dez";
                    default:
                        return "";
                }
            }
        }

        public override string ToString()
        {
            return Name + " de " + base.suit.ToNameString();
        }
    }
}
