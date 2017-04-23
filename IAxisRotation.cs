using System.Collections.Generic;

namespace TspAxesRot
{
    public interface IAxisRotation
    {
        double GetDistanceBetweenNodes(Coordinate n1, Coordinate n2);

        TspProcessedData DoGreedyTspWithNoReturn(List<Node> graphNodes);
        TspProcessedData DoAxesRotationTspWithNoReturn(List<Node> graphNodes);
    }
}