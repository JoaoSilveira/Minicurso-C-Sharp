using System.Drawing;

namespace Minicurso_C_Sharp
{
    // interface que todo objeto desenhável deve implementar
    public interface IDraw
    {
        void Draw(Graphics graphics);
    }
}