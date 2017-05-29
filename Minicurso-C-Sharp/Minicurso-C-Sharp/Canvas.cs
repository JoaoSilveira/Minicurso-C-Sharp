using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minicurso_C_Sharp
{
    public sealed class Canvas : Panel
    {
        // cria um panel com um buffer duplo, isso tira o flicker
        // famosa piscada quando tá desenhando, vai no form1.designer pra ver como faz
        public Canvas()
        {
            DoubleBuffered = true;
        }
    }
}
