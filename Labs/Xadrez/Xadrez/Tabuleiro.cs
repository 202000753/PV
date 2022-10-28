using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    // Nível 5
    public class Tabuleiro
    {
        private Peca[,] tabuleiro;

        public Tabuleiro()
        {
            tabuleiro = new Peca[8, 8];

            for (int x = 0; x < 8; x++)
            {
                tabuleiro[x, 1] = new Peao(Cor.Branco, new Posicao((char)('a' + x), 2));
                tabuleiro[x, 6] = new Peao(Cor.Preto, new Posicao((char)('a' + x), 7));
            }
            int line = 1;
            Cor branca = Cor.Branco;
            tabuleiro[0, 0] = new Torre(branca, new Posicao('a', line));
            tabuleiro[1, 0] = new Cavalo(branca, new Posicao('b', line));
            tabuleiro[2, 0] = new Bispo(branca, new Posicao('c', line));
            tabuleiro[3, 0] = new Rainha(branca, new Posicao('d', line));
            tabuleiro[4, 0] = new Rei(branca, new Posicao('e', line));
            tabuleiro[5, 0] = new Bispo(branca, new Posicao('f', line));
            tabuleiro[6, 0] = new Cavalo(branca, new Posicao('g', line));
            tabuleiro[7, 0] = new Torre(branca, new Posicao('h', line));

            line = 8;
            Cor preta = Cor.Preto;
            tabuleiro[0, 7] = new Torre(preta, new Posicao('a', line));
            tabuleiro[1, 7] = new Cavalo(preta, new Posicao('b', line));
            tabuleiro[2, 7] = new Bispo(preta, new Posicao('c', line));
            tabuleiro[3, 7] = new Rainha(preta, new Posicao('d', line));
            tabuleiro[4, 7] = new Rei(preta, new Posicao('e', line));
            tabuleiro[5, 7] = new Bispo(preta, new Posicao('f', line));
            tabuleiro[6, 7] = new Cavalo(preta, new Posicao('g', line));
            tabuleiro[7, 7] = new Torre(preta, new Posicao('h', line));
        }

        // Criação de um indexer para o tabuleiro
        public Peca this[char x, int y]
        {
            get
            {
                // assumindo os valores de x e y válidos
                return tabuleiro[x - 'a', y - 1];
            }
            set
            {
                // assumindo os valores de x e y válidos
                tabuleiro[x - 'a', y - 1] = value;
            }
        }

        public void Mostrar()
        {

            for (int y = 7; y >= 0; y--)
            {
                Console.Write(y + 1 + "  ");
                for (int x = 0; x < 8; x++)
                {
                    Peca peca = tabuleiro[x, y];
                    if (peca == null)
                    {
                        Console.Write("  ");
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
