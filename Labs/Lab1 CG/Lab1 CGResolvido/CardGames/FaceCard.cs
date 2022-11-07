using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    // Nível 2
    public class FaceCard : Card
    {
        private FaceName faceName;

        public FaceCard()
        {

        }

        public FaceCard(FaceName faceName, Suit suit, int value) : base(suit, value)
        {
            this.faceName = faceName;
        }

        public FaceCard(FaceName faceName, Suit suit) : base(suit)
        {
            this.faceName = faceName;
        }

        public FaceName FaceName => faceName;

        // Nível 3 +ToNameString()
        public override string Name => faceName.ToNameString();

    }
}
