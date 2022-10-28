using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{

    // Nivel 1
    public class Circulo : Figura
    {
        private int raio;

        public Circulo()
        {
            raio = 1;
        }

        public Circulo(int raio)
        {
            this.raio = raio;
        }

        public Circulo(int x, int y, int raio)
            : base(x, y)
        {
            this.raio = raio;
        }

        public int GetRaio()
        {
            return raio;
        }

        public void SetRaio(int raio)
        {
            this.raio = raio;
        }

        // Nivel 2


        public override double GetArea()
        {
            return Math.PI * raio * raio;
        }

        // Nivel 2
        public override string ToString()
        {
            return base.ToString() + " R=" + raio;
        }
    }
}
