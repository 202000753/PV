using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    // Nível 4
    public class Cavalo : Peca
    {
        public Cavalo(Cor cor, Posicao posicao) : base(cor, posicao)
        {
        }

        public override string ToString() => "C" + base.ToString();

        public override string Simbolo => "C";

        public override string Nome => "Cavalo";

        public override void Deslocar(int dx, int dy)
        {
            throw new NotImplementedException();
        }
    }
}
