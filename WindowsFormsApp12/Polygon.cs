using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp12
{
    public struct Polygon
    {
        public List<Vector> Vertexes { get; set; }
        public List<Segment> Sides { get; set; }
        public Polygon(List<Vector> vertexes)
        {
            Vertexes = vertexes;
            var sides = new List<Segment>();
            for (int i = 0; i < vertexes.Count - 1; i++)
            {
                sides.Add(new Segment(vertexes[i], vertexes[i + 1]));
            }
            sides.Add(new Segment(vertexes[vertexes.Count-1], vertexes[0]));
            Sides = sides;
        }
    }
}
