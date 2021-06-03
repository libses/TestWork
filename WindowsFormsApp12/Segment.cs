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
        public Vector GetCrossingVector(Line line)
        {
            var segmentLine = Line.GetLineFromSegment(this);
            return line.GetCrossingWithOther(segmentLine);
        }
        public bool CheckIfCrossingBelongsToSegment(Vector vector)
        {
            var maxX = Math.Max(Start.X, End.X);
            var maxY = Math.Max(Start.Y, End.Y);
            var minX = Math.Min(Start.X, End.X);
            var minY = Math.Min(Start.Y, End.Y);
            return vector.X <= maxX && vector.X >= minX && vector.Y <= maxY && vector.Y >= minY;
        }
        public bool CheckIfThereCrossingWithLine(Line line)
        {
            return CheckIfCrossingBelongsToSegment(GetCrossingVector(line));
        }
    }
}
