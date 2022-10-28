using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Lab0
{
    internal abstract class Peca : IMover
    {
        private Cor cor;
        private Posicao posicao;

        private string simbolo = "";

        public Peca(Cor cor, Posicao posicao)
        {
            this.cor = cor;
            this.posicao = posicao ?? new Posicao();
        }

        public bool IsBranca => cor == Cor.Branco;
        public bool IsPreta => cor == Cor.Preto;

        public Posicao Posicao
        {
            get => new Posicao(posicao.X, posicao.Y);

            set
            {
                if (value == null)
                    return;

                this.posicao.X = value.X;
                this.posicao.Y = value.Y;
            }
        }

        public void SetPosicao(char x, int y)
        {
            posicao.X = x;
            posicao.Y = y;
        }

        public char X
        {
            get => posicao.X;
            set => posicao.X = value;
        }

        public int Y
        {
            get => posicao.Y;
            set => posicao.Y = value;
        }

        public override string ToString() => posicao.ToString();

        public abstract string Nome { get; }

        public abstract void Deslocar(int dx, int dy);

        public virtual string Simbolo => simbolo;
    }
}
