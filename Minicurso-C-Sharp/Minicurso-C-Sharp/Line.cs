using System.Drawing;

namespace Minicurso_C_Sharp
{
    public class Line : IDraw
    {
        public Point InitialPoint { get; set; }
        public Point EndPoint { get; set; }

        public Line()
        {

        }

        public Line(Point initialPoint, Point endPoint)
        {
            InitialPoint = initialPoint;
            EndPoint = endPoint;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawLine(new Pen(Color.Black), InitialPoint, EndPoint);
        }
    }
}