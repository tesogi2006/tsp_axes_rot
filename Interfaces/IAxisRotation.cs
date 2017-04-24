using System.Collections.Generic;
using TspAxesRot.Domain;

namespace TspAxesRot.Interfaces
{
    public interface IAxisRotation
    {
        double GetDistanceBetweenNodes(Coordinate n1, Coordinate n2);

        TspProcessedData DoGreedyTspWithNoReturn(List<Node> graphNodes);
        TspProcessedData DoAxesRotationTspWithNoReturn(List<Node> graphNodes);
    }
}