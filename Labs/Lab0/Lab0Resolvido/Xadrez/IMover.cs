using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    public interface IMover
    {
        void Deslocar(int dx, int dy);
    }
}
