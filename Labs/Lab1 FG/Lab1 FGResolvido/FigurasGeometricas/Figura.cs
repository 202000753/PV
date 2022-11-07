using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{
    // Nivel 1
    public abstract class Figura : IMover  // IMover - Nivel 4
    {
        private int x = 0;
        private int y = 0;

        public Figura()
        {

        }

        public Figura(int x, int y)
        {
            this.SetX(x);
            this.SetY(y);
        }


        public int GetX()
        {
            return x;
        }

        public void SetX(int value)
        {
            x = value;
        }

        public int GetY()
        {
            return y;
        }

        public void SetY(int value)
        {
            y = value;
        }


        // Nivel 2 ou 3
        public abstract double GetArea();


        // Nivel 2
        public override string ToString()
        {
            return "(" + GetX() + "," + GetY() + ")";
        }


        // Nivel 4
        public void Deslocar(int dx, int dy)
        {
            SetX(GetX() + dx);
            SetY(GetY() + dy);
        }


        public int DeslocarX(int dx)
        {
            SetX(GetX() + dx);
            return GetX();
        }


        public void MostrarX()
        {
            Console.WriteLine("x = " + GetX());
        }
    }
}
