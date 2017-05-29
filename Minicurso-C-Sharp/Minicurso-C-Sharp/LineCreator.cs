using System;
using System.Windows.Forms;

namespace Minicurso_C_Sharp
{
    public class LineCreator : ICreate
    {
        private Control _control;
        private readonly Line _line;
        private int _count;

        public IDraw Result => _line;

        public event EventHandler Finished;
        public event EventHandler Cancelled;

        public LineCreator()
        {
            _count = 0;
            _line = new Line();
        }

        // limpa os eventos do mouse e variáveis
        public void ClearEvents()
        {
            _control.MouseClick -= MouseClick;
            _control.MouseMove -= MouseMove;
            _control = null;
            _count = 0;
        }

        // inicializa eventos do mouse
        public void RegisterEvents(Control control)
        {
            _control = control;

            control.MouseClick += MouseClick;
            control.MouseMove += MouseMove;
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (_count != 1) return;

            // se o mouse se mexeu e a linha começou a ser desenhada, atualiza a linha
            _line.EndPoint = e.Location;
            _control.Refresh();
        }

        private void MouseClick(object sender, MouseEventArgs e)
        {
            _count++;

            if (_count == 2 && e.Button == MouseButtons.Right)
            {
                // cancela a criação de linhas
                // acesso condicional invoke só é chamado se Cancelled não foi nulo
                Cancelled?.Invoke(this, EventArgs.Empty);
                return;
            }

            switch (_count)
            {
                case 1:
                    _line.InitialPoint = e.Location;
                    break;
                case 2: // terminou de desenhar a linha
                    _line.EndPoint = e.Location;
                    Finished?.Invoke(this, EventArgs.Empty);
                    break;
            }
        }
    }
}