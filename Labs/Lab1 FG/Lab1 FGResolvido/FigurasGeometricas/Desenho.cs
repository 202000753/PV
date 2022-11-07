using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{
    // Nivel 3
    public class Desenho : IMover  // IMover - Nivel 4
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

        public int GetNumeroFiguras()
        {
            return figuras.Count;
        }

        // Nivel 4
        public void Deslocar(int dx, int dy)
        {
            foreach (Figura figura in figuras)
                figura.Deslocar(dx, dy);
        }


        // Nivel 3
        public override string ToString()
        {
            string txt = "";

            txt += "Desenho:";
            int count = 0;
            foreach (Figura figura in figuras)
                txt += "\nfig" + count++ + " - " + figura.ToString();
            return txt;
        }


        // Nivel 5
        public double GetArea()
        {
            double area = 0.0;
            foreach (Figura figura in figuras)
                area += figura.GetArea();

            return area;
        }

        // Nivel 5
        public void RemoverFigura(int indice)
        {
            figuras.Remove(figuras[indice]);
        }
    }
}
