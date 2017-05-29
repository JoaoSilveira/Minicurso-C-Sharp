using System;
using System.Windows.Forms;

namespace Minicurso_C_Sharp
{
    // interface que todo criador tem que implementar
    public interface ICreate
    {
        // eventos de cancelamento ou término
        event EventHandler Finished;
        event EventHandler Cancelled;

        void RegisterEvents(Control control);
        void ClearEvents();

        IDraw Result { get; }
    }
}