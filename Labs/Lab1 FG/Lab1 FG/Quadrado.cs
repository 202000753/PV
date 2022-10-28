using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_FG
{
    internal class Quadrado : Figura
    {
        private int lado;

        public Quadrado() : base(1, 1)
        {
            lado = 1;
        }

        public Quadrado(int l) : base(1, 1)
        {
            lado = l;
        }
        public Quadrado(int l, int x, int y) : base(x, y)
        {
            lado = l;
        }

        public void SetLado(int l) { lado= l; }

        public int GetLado() { return lado; }

        public override string ToString()
        {
            return base.ToString() + " L= " + GetLado();
        }

        public override double GetArea()
        {
            return lado * lado;
        }
    }
}
