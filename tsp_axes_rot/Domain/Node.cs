namespace TspAxesRot.Domain
{
    public class Node
    {
        public Coordinate Coord { get; set; }
        public bool Visited { get; set; }
        public bool IsStartOrEnd { get; set; }
    }
}