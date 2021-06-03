using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp12
{
    public struct Segment
    {
        public Vector Start { get; set; }
        public Vector End { get; set; }
        public Vector MainVector { get
            {
                return End - Start;
            } }
        public double Length { get
            {
                return MainVector.Length;
            } }
        public Segment(Vector start, Vector end)
        {
            Start = start;
            End = end;
        }
    }
}
