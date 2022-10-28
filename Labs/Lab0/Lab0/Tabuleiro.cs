using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab0
{
    internal class Tabuleiro
    {
        public Peca[,] tabuleiro;

        public Tabuleiro()
        {
            tabuleiro = new Peca[8, 8];

            for (int i = 0; i < 8; i++)
            {
                tabuleiro[i, 1] = new Peao(Cor.Branco, new Posicao((char)('a' + i), 2));
                tabuleiro[i, 6] = new Peao(Cor.Preto, new Posicao((char)('a' + i), 7));
            }

            int line = 1;
            Cor branco = Cor.Branco;
            Cor preto = Cor.Preto;

            tabuleiro[0, 0] = new Torre(branco, new Posicao('a', line));
            tabuleiro[1, 0] = new Cavalo(branco, new Posicao('b', line));
            tabuleiro[2, 0] = new Bispo(branco, new Posicao('c', line));
            tabuleiro[3, 0] = new Rainha(branco, new Posicao('d', line));
            tabuleiro[4, 0] = new Rei(branco, new Posicao('e', line));
            tabuleiro[5, 0] = new Bispo(branco, new Posicao('f', line));
            tabuleiro[6, 0] = new Cavalo(branco, new Posicao('g', line));
            tabuleiro[7, 0] = new Torre(branco, new Posicao('h', line));


            line = 8;
            tabuleiro[0, 7] = new Torre(preto, new Posicao('a', line));
            tabuleiro[1, 7] = new Cavalo(preto, new Posicao('b', line));
            tabuleiro[2, 7] = new Bispo(preto, new Posicao('c', line));
            tabuleiro[3, 7] = new Rainha(preto, new Posicao('d', line));
            tabuleiro[4, 7] = new Rei(preto, new Posicao('e', line));
            tabuleiro[5, 7] = new Bispo(preto, new Posicao('f', line));
            tabuleiro[6, 7] = new Cavalo(preto, new Posicao('g', line));
            tabuleiro[7, 7] = new Torre(preto, new Posicao('h', line));
        }

        public Peca this[char x, int y]
        {
            get
            {
                return tabuleiro[x - 'a', y - 1];
            }

            set
            {
                tabuleiro[x - 'a', y - 1] = value;
            }
        }

        public void Mostrar ()
        {
            for (int y = 7; y >= 0; y--)
            {
                Console.Write(y + 1 + " ");

                for (int x = 0; x < 8; x++)
                {
                    Peca peca = tabuleiro[x, y];

                    if (peca == null)
                    {
                        Console.Write(" ");
                        continue;
                    }

                    if (peca.IsBranca)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write(peca.Simbolo + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();
            }

            Console.WriteLine("   a b c d e f g h");
        }
    }
}
