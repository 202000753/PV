using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0
{
    internal class Peao : Peca
    {
        public Peao(Cor cor, Posicao posicao) : base(cor, posicao)
        {
        }

        public override string Nome => "Peão";
        public override string Simbolo => "P";

        public override void Deslocar(int dx, int dy) => Y += dy;

        public static Peao operator ++(Peao peao)
        {
            peao.Deslocar(0, 1);
            return peao;
        }
    }
}
