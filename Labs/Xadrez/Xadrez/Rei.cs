using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    // Nível 4
    public class Rei : Peca
    {
        public Rei(Cor cor, Posicao posicao) : base(cor, posicao)
        {
        }

        public override string ToString() => "R" + base.ToString();


        public override string Nome => "Rei";

        public override string Simbolo => "R";

        public override void Deslocar(int dx, int dy)
        {
            throw new NotImplementedException();
        }
    }
}
