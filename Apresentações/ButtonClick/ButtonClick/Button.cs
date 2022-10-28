using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonClick
{
    public delegate void SimpleMethod();
    public class Button
    {
        public event SimpleMethod Click;

        public void Press()
        {
            if (Click != null)
                Click();

        }
    }
}
