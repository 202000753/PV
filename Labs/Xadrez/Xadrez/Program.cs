// See https://aka.ms/new-console-template for more information

using Xadrez;


// Nível 1
Console.WriteLine("    Nível 1    \n");

Posicao pos1 = new Posicao('e', 7); //posicao x e y
Posicao pos2 = new Posicao();

Console.WriteLine("Posicao: " + pos1);
Console.WriteLine("Posicao: " + pos2.X + pos2.Y);

Console.ReadKey();

// Nível 2
Console.Clear();
Console.WriteLine("    Nível 2    \n");

Peao p1 = new Peao(Cor.Preto, new Posicao('e', 5));
Peao p2 = new Peao(Cor.Branco, new Posicao());
p2.SetPosicao('d', 2);

Console.WriteLine("Peão 1 - " + p1);
Console.WriteLine("Peão 2 - " + p2);

Console.Write("Peão 1 na posicao: ");
Console.WriteLine("" + p1.X + p1.Y);

Console.Write("Peão 2 na posicao: ");
Console.WriteLine("" + p2.X + p2.Y);

Torre t1 = new Torre(Cor.Branco, pos2);

Console.WriteLine("Torre - " + t1);
Console.ReadKey();

// Nível 3
Console.Clear();
Console.WriteLine("    Nível 3    \n");

Peca[] pecas = new Peca[] { p1, p2, t1 };
Console.WriteLine("Peças no array:");

foreach (Peca peca in pecas)
    Console.WriteLine(peca.Nome);

Console.ReadKey();

// Nível 4
Console.Clear();
Console.WriteLine("    Nível 4    \n");

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

Console.WriteLine("Peão - " + p1);
Console.WriteLine("Mover o Peão p1++");
p1++;
Console.WriteLine("Peão - " + p1);

Console.ReadKey();

// Nível 5
Console.Clear();
Console.WriteLine("    Nível 5    \n");

Tabuleiro tabuleiro = new Tabuleiro();
tabuleiro.Mostrar();

Console.ReadKey();

// Nível 5
Console.Clear();
Console.WriteLine("    Desafio - Indexers    \n");
tabuleiro['e', 4] = tabuleiro['e', 2];
tabuleiro['e', 2] = null;
tabuleiro.Mostrar();

Console.ReadKey();