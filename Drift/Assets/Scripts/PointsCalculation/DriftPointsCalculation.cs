using UnityEngine;

namespace Drift.PointsCalculation
{
    public class DriftPointsCalculation : MonoBehaviour
    {
        int factor = 2;
        int totalPoints = 0;
        int circlePoints = 0;

        public int CurrentCirclePoints(float circleDistance)
        {
            circlePoints = (int)circleDistance * factor;
            return circlePoints;
            //TODO: add increase factor 
        }

        public int TotalPoints(float points)
        {
            totalPoints += (int)points;
            return totalPoints;
        }
    }
}