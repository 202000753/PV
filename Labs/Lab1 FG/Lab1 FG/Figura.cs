using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_FG
{
    internal abstract class Figura : IMover
    {
        private int x = 0;
        private int y = 0;

        public Figura()
        {

        }

        public Figura(int x, int y)
        {
            SetX(x);
            SetY(y);
        }

        private void SetY(int value) { y = value; }

        private void SetX(int value)  { x = value; }

        private int GetY() { return y; }

        private int GetX() { return x; }

        public override string ToString()
        {
            return "(" + GetX() + ", " + GetY() + ")";
        }

        public abstract double GetArea();

        public void Deslocar(int dx, int dy)
        {
            SetY(dx);
            SetY(dy);
        }
    }
}
