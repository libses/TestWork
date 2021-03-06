using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp12
{
    public struct Line
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public Vector Normal { get
            {
                return new Vector(A, B);
            } }
        public Vector Main { get
            {
                return new Vector(-B, A);
            } }
        public Line(Vector point, Vector main)
        {
            A = main.Y;
            B = -main.X;
            C = -A * point.X - B * point.Y;
        }
        public static Line GetLineFromSegment(Segment segment)
        {
            var main = segment.MainVector;
            var point = segment.Start;
            return new Line(point, main);
        }
        public bool CheckIfParallel(Line line)
        {
            return Math.Abs(A * line.B - line.A * B) < 0.000001;
        }
        public Vector GetCrossingWithOther(Line line)
        {
            var x = -(C * line.B - line.C * B) / (A * line.B - line.A * B);
            var y = -(A * line.C - line.A * C) / (A * line.B - line.A * B);
            return new Vector(x, y);
        }
        public bool IsPositive(Vector vector, Vector rayStart)
        {
            var alpha = Main.X;
            var beta = Main.Y;
            if (alpha == 0)
            {
                return (vector.Y - rayStart.Y) / beta > 0;
            }
            if (beta == 0)
            {
                return (vector.X - rayStart.X) / alpha > 0;
            }
            return (vector.Y - rayStart.Y) / beta > 0 && (vector.X - rayStart.X) / alpha > 0;
        }
    }
}
