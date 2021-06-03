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
        public Line(Vector point, Vector main)
        {
            A = main.Y;
            B = -main.X;
            C = -A * point.X - B * point.Y;
        }
        public Line GetLineFromSegment(Segment segment)
        {
            var main = segment.MainVector;
            var point = segment.Start;
            return new Line(point, main);
        }
        
    }
}
