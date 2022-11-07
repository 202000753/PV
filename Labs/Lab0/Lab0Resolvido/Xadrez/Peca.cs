using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{

    // Nível 2
    public abstract class Peca : IMover
    {
        private Cor cor;
        private Posicao posicao;

        // Nível 5
        private string simbolo = "";

        public Peca(Cor cor, Posicao posicao)
        {
            this.cor = cor;

            // Uso de null-coalescing operator
            this.posicao = posicao ?? new Posicao();
        }

        // passou a propriedade
        public bool IsBranca => cor == Cor.Branco;

        // passou a propriedade
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



        // Criadas as propriedades X e Y em vez dos get e set anteriores
        // Usou-se "expression body" nos métodos get e set
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

        // uso de expression body
        public override string ToString() => posicao.ToString();

        // Nível 3
        // Substituiçao de GetNome por uma propriedade abstrata apenas de leitura
        public abstract string Nome { get; }

        // Nível 4
        public abstract void Deslocar(int dx, int dy);

        // Nível 5
        // Substituiçao de GetSimbolo por uma propriedade apenas de leitura
        public virtual string Simbolo => simbolo;
    }

}
