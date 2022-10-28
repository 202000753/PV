using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0
{
    internal class Cavalo : Peca
    {
        public Cavalo(Cor cor, Posicao posicao) : base(cor, posicao)
        {
        }

        public override string Nome => "Cavalo";
        public override string Simbolo => "C";

        public override void Deslocar(int dx, int dy)
        {
            throw new NotImplementedException();
        }
    }
}
