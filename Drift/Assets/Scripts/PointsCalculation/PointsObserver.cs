using UnityEngine;
using Drift.DriftUIElements;
using Drift.CarMove;

namespace Drift.PointsCalculation
{
    public class PointsObserver : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] SelectTarget selectTarget;
        [SerializeField] DriftTracker driftTracker;
        [Header("Delegates")]
        [SerializeField] DriftPointsCalculation pointsCalculation;
        [SerializeField] DriftBar driftBar;
        [SerializeField] DriftPointsText driftPointsText;
        [SerializeField] TotalPointsText totalPointsText;

        void Start()
        {
            selectTarget.newPoint += CalculateTotalPoints;
            driftTracker.Drifting += GetCurrentCompleteDistance;
            driftPointsText.enabled = false;
            totalPointsText.textChange(0);
        }

        void OnDestroy()
        {
            selectTarget.newPoint -= CalculateTotalPoints;
            driftTracker.Drifting -= GetCurrentCompleteDistance;
        }

        void CalculateTotalPoints()
        {
            float currentDriftPoints = driftTracker.CurrentLapDistance;
            int totalPoints = pointsCalculation.TotalPoints(currentDriftPoints);
            totalPointsText.textChange(totalPoints);
            driftPointsText.enabled = false; //TODO: don't work, complete later

            driftTracker.CircleIsDone();
            driftTracker.enabled = true;
        }

        void GetCurrentCompleteDistance(float distance)
        {
            int circlePoints = pointsCalculation.CurrentCirclePoints(distance);
            driftBar.BarChange(distance, driftTracker.MaxDistance);

            driftPointsText.enabled = true;
            driftPointsText.textChange(circlePoints);
        }
    }
}