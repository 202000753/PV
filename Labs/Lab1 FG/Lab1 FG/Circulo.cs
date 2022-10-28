using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_FG
{
    internal class Circulo : Figura
    {
        private int raio;

        public Circulo() : base(1, 1)
        {
            raio = 1;
        }

        public Circulo(int r) : base(1, 1)
        {
            raio = r;
        }
        public Circulo(int r, int x, int y) : base(x, y)
        {
            raio = r;
        }

        public void SetRaio(int r) { raio =r; }

        public int GetRaio() { return raio; }

        public override string ToString()
        {
            return base.ToString() + " R= " + GetRaio();
        }

        public override double GetArea()
        {
            return Math.PI * GetRaio() * GetRaio();
        }
    }
}
