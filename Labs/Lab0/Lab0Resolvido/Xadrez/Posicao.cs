using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    public class Posicao
    {
        // Usa propriedades implicitas
        public char X { get; set; }

        public int Y { get; set; }


        // Constantes com Pascal Case - Convenção do C#
        private const char XInicial = 'a';
        private const int YInicial = 1;

        public Posicao(char x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        // Usa o contrutor que recebe x e y
        public Posicao() : this(XInicial, YInicial)
        {
        }


        public override string ToString()
        {
            // Em vez de concatenação, usaram-se strings interpoladas
            return $"{X}{Y}";
        }

    }
}
