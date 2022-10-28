using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{

    // Nível 4
    public class Rainha : Peca
    {
        public Rainha(Cor cor, Posicao posicao) : base(cor, posicao)
        {
        }

        public override string ToString() => "D" + base.ToString();

        public override string Simbolo => "D";

        public override string Nome => "Rainha";


        public override void Deslocar(int dx, int dy)
        {
            throw new NotImplementedException();
        }
    }
}
