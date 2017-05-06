using System.Collections.Generic;

namespace TspAxesRot.Domain
{
    public class TspProcessedData
    {
        public Queue<Coordinate> Path { get; set;}
        public double DistanceTravelled { get; set; }
    }
}