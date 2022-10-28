using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0
{
    internal class Torre : Peca
    {
        public Torre(Cor cor, Posicao posicao) : base(cor, posicao)
        {
        }

        public override string ToString() => "T" + base.ToString();

        public override string Nome => "Torre";
        public override string Simbolo => "T";

        public override void Deslocar(int dx, int dy)
        {
            if (dx != 0 && dy != 0)
                return;

            X = (char)(X + dx);
            Y += dy;
        }


    }
}
