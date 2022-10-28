using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0
{
    internal class Posicao
    {
        public char X { get; set; }
        public int Y { get; set; }

        private const char XInicial = 'a';
        private const int YInicial = 1;

        public Posicao(char x, int y)
        {
            X = x;
            Y = y;
        }

        public Posicao() : this (XInicial, YInicial)
        {
        }
        

        public override string ToString()
        {
            return $"{X}{Y}";
        }
    }
}
