using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_FG
{
    internal class Desenho : IMover
    {
        private IList<Figura> figuras;

        public Desenho()
        {
            figuras = new List<Figura>();
        }

        public void AdicionarFigura(Figura figura)
        {
            figuras.Add(figura);
        }

        public override string ToString()
        {
            string txt = "Desenho:";

            int count = 0;
            foreach (Figura figura in figuras)
                txt += "\nfig(" + count++ +") - " + figura.ToString();

            return txt;
        }

        public void Deslocar(int x, int y)
        {
            foreach(Figura figura in figuras)
                figura.Deslocar(x, y);
        }

        public double GetArea()
        {
            double area = 0;

            foreach (Figura figura in figuras)
                area += figura.GetArea();

            return area;
        }

        public void RemoverFigura(int indice)
        {
            figuras.Remove(figuras[indice]);
        }
    }
}
