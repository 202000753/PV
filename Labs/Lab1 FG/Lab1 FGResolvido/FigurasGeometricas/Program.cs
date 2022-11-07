// See https://aka.ms/new-console-template for more information

using FigurasGeometricas;

// Niveis 1 e 2
Circulo circ1 = new Circulo(1, 2, 10);
Quadrado quad1 = new Quadrado(5);
Quadrado quad2 = new Quadrado(1, 2, 10);

circ1.SetX(10);
Console.WriteLine(circ1.GetX());
circ1.MostrarX();

Console.WriteLine("Figuras:");
Console.WriteLine(circ1 + " A=" + circ1.GetArea());
Console.WriteLine(quad1 + " A=" + quad1.GetArea());
Console.WriteLine(quad2 + " A=" + quad2.GetArea());

// Nivel 3
Desenho des1 = new Desenho();

des1.AdicionarFigura(circ1);
des1.AdicionarFigura(quad1);
des1.AdicionarFigura(quad2);

Console.WriteLine();
Console.WriteLine(des1);

// Nivel 4
IMover[] movs = new IMover[3];

Circulo circ2 = new Circulo(0, 0, 15);
Quadrado quad3 = new Quadrado(1, 1, 7);

movs[0] = circ2;
movs[1] = quad3;
movs[2] = des1;

Console.WriteLine("\nMover (0,2):");
for (int i = 0; i < movs.Length; i++)
{
    movs[i].Deslocar(0, 2);
    Console.WriteLine(i + " - " + movs[i].ToString());
}

// Nivel 5
Console.WriteLine("\nArea total das figuras:");
Console.WriteLine("Area = " + des1.GetArea());

Console.WriteLine("\n" + des1);
Console.WriteLine("\nRemover Figura (1)");
des1.RemoverFigura(1);
Console.WriteLine(des1);
Console.ReadKey();
