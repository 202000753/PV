using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_CG
{
    internal class FaceCard : Card
    {
        public FaceName faceName { get; set; }

        public FaceCard(FaceName fN, Suit s, int v) : base(s, v)
        {
            faceName = fN;
        }

        public FaceCard(FaceName fN, Suit s) : base(s)
        {
            faceName = fN;
        }

        public FaceCard()
        {
            
        }

        public FaceName FaceName { get => faceName; }

        public override string Name
        {
            get
            {
                return faceName.ToNameString();
                /*switch (faceName)
                {
                    case FaceName.Valete:
                        return "Valete";
                    case FaceName.Rainha:
                        return "Rainha";
                    case FaceName.Rei:
                        return "Rei";
                    default:
                        return "";
                }*/
            }
        }

        public override string ToString()
        {
            return Name + " de " + base.suit.ToNameString();
        }
    }
}
