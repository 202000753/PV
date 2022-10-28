using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0
{
    internal class Rainha : Peca
    {
        public Rainha(Cor cor, Posicao posicao) : base(cor, posicao)
        {
        }

        public override string Nome => "Rainha";
        public override string Simbolo => "D";

        public override void Deslocar(int dx, int dy)
        {
            throw new NotImplementedException();
        }
    }
}
