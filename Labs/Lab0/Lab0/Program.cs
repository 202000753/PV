using Lab0;

//Nivel 1
Console.WriteLine("\n\n    Nível 1    \n");
Posicao posicao1 = new Posicao();
Posicao posicao2 = new Posicao('b', 4);

Console.WriteLine($"Posição 1= {posicao1}");
Console.WriteLine($"Posição 2= {posicao2}");


Console.ReadKey();
//Console.Clear();

// Nível 2
Console.WriteLine("\n\n    Nível 2    \n");
Peao p1 = new Peao(Cor.Branco, new Posicao());
Peao p2 = new Peao(Cor.Branco, new Posicao('f', 5));
p1.SetPosicao('d', 2);

Console.WriteLine("Peão 1 - " + p1);
Console.WriteLine("Peão 2 - " + p2);

Console.Write("Peão 1 na posicao: ");
Console.WriteLine("" + p1.Posicao);

Console.Write("Peão 2 na posicao: ");
Console.WriteLine("" + p2.X + p2.Y);

Torre t1 = new Torre(Cor.Branco, posicao2);

Console.WriteLine("Torre - " + t1);

Console.ReadKey();
//Console.Clear();

// Nível 3
Console.WriteLine("\n\n    Nível 3    \n");
Peca[] pecas = new Peca[] { p1, p2, t1};

Console.WriteLine("Peças no Array");
foreach (Peca peca in pecas)
{
    Console.WriteLine(peca.Nome);
}

// Nível 4
Console.WriteLine("\n\n    Nível 4    \n");
Console.WriteLine("Torre - " + t1);
Console.WriteLine("Mover a Torre dx=2");
t1.Deslocar(2, 0);
Console.WriteLine("Torre - " + t1);

Console.WriteLine("Mover a Torre dy=1");
t1.Deslocar(0, 1);
Console.WriteLine("Torre - " + t1);

Console.WriteLine("Mover a Torre dx=3 e dy=3");
t1.Deslocar(3, 3);
Console.WriteLine("Torre - " + t1);

Console.WriteLine("Peão - " + p1);
Console.WriteLine("Mover o Peão dx=1");
p1.Deslocar(1, 0);
Console.WriteLine("Peão - " + p1);

Console.WriteLine("Mover o Peão dy=1");
p1.Deslocar(0, 1);
Console.WriteLine("Peão - " + p1);

Console.WriteLine("Mover o Peão dx=1 e dy=1");
p1.Deslocar(1, 1);
Console.WriteLine("Peão - " + p1);

Console.WriteLine("Mover o Peão p1++");
p1++;
Console.WriteLine("Peão - " + p1);

Console.ReadKey();

// Nível 5
Console.WriteLine("\n\n    Nível 5    \n");

Tabuleiro tabuleiro = new Tabuleiro();
tabuleiro.Mostrar();