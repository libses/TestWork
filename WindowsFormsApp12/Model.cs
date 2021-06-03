using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp12
{
    public class Model
    {
        Polygon polygon;
        Vector point;
        Random random;
        public Model() { random = new Random(); }
        public Model(Polygon poly, Vector vector)
        {
            polygon = poly;
            point = vector;
            random = new Random();
        }
        public string MakeChecks()
        {
            var boolList = new List<bool>();
            for (int i = 0; i < 20000; i++)
            {
                var randomX = random.Next(1, 1000);
                var randomY = random.Next(1, 1000);
                var line = new Line(point, new Vector(randomX, randomY));
                var counter = 0;
                var isVert = false;
                foreach (var side in polygon.Sides)
                {
                    var crossVector = side.GetCrossingVector(line);
                    var isPositive = line.IsPositive(crossVector, point);
                    var isBelongs = side.CheckIfCrossingBelongsToSegment(crossVector);
                    if (isBelongs && isPositive)
                    {
                        foreach (var vert in polygon.Vertexes)
                        {
                            if (Vector.IsAlmostEqual(crossVector, vert))
                            {
                                isVert = true;
                                break;
                            }
                        }
                    }
                    if (isVert) break;
                    if (isPositive && isBelongs && !isVert)
                    {
                        counter++;
                    }
                }
                if (isVert) continue;
                if (counter % 2 == 1)
                {
                    boolList.Add(true);
                } else
                {
                    boolList.Add(false);
                }
            }
            if (boolList.All(x => x == true))
            {
                return "inside";
            } else if (boolList.All(x => x == false))
            {
                return "outside";
            } else
            {
                throw new Exception();
            }
        }
    }
}
