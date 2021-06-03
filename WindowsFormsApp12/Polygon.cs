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
        public Polygon(List<Vector> vertexes)
        {
            Vertexes = vertexes;
        }
    }
}
