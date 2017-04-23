namespace TspAxesRot
{
    public class Coordinate
    {
        public double X { get; set; }
        public double Y { get; set; }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    public class Node
    {
        public Coordinate Coord { get; set; }
        public bool Visited { get; set; }
        public bool IsStartOrEnd { get; set; }
    }
}