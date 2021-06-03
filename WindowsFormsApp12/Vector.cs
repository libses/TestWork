using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp12
{
    public struct Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Length { 
            get
            {
                return Math.Sqrt(X * X + Y * Y);
            } 
        }
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        public static Vector operator *(Vector vector, double scalar)
        {
            return new Vector(vector.X * scalar, vector.Y * scalar);
        }
        public static Vector operator *(double scalar, Vector vector)
        {
            return vector * scalar;
        }
        public static Vector operator +(Vector first, Vector second)
        {
            return new Vector(first.X + second.X, first.Y + second.Y);
        }
        public static Vector operator -(Vector first, Vector second)
        {
            return new Vector(first.X - second.X, first.Y - second.Y);
        }
        public double GetScalar(Vector first, Vector second)
        {
            return first.X * second.X + first.Y * second.Y;
        }
    }
}
