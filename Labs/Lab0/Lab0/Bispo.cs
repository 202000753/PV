using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0
{
    internal class Bispo : Peca
    {
        public Bispo(Cor cor, Posicao posicao) : base(cor, posicao)
        {
        }

        public override string Nome => "Bispo";
        public override string Simbolo => "B";

        public override void Deslocar(int dx, int dy)
        {
            throw new NotImplementedException();
        }
    }
}
