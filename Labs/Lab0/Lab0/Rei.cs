using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0
{
    internal class Rei : Peca
    {
        public Rei(Cor cor, Posicao posicao) : base(cor, posicao)
        {
        }

        public override string Nome => "Rei";
        public override string Simbolo => "R";

        public override void Deslocar(int dx, int dy)
        {
            throw new NotImplementedException();
        }
    }
}
