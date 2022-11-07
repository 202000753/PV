using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{
    // Nivel 1
    public class Quadrado : Figura
    {
        private int lado;

        public Quadrado()
        {
            lado = 1;
        }

        public Quadrado(int lado)
        {
            this.lado = lado;
        }

        public Quadrado(int x, int y, int lado)
            : base(x, y)
        {
            this.lado = lado;
        }

        public void SetLado(int lado)
        {
            this.lado = lado;
        }

        public int GetLado()
        {
            return lado;
        }

        // Nivel 2
        public override double GetArea()
        {
            return lado * lado;
        }

        // Nivel 2
        public override string ToString()
        {
            return base.ToString() + " L=" + lado;
        }
    }
}
