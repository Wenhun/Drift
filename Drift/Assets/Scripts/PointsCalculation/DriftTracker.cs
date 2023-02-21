using System;
using UnityEngine;

namespace Drift.PointsCalculation
{
    public class DriftTracker : MonoBehaviour
    {
        [SerializeField] Transform tracker;
        [SerializeField] Transform tracker_2;

        Vector3 lastPosition;

        float lapDistance;
        float maxDistance;

        bool isDrifting = false;

        public float CurrentLapDistance { get => lapDistance; }
        public float MaxDistance { get => maxDistance; }

        public event Action<float> Drifting;

        void Awake()
        {
            maxDistance = Mathf.PI * Vector2.Distance(tracker.position, tracker_2.position);
        }

        void Update()
        {
            if (isDrifting)
            {
                CalculateDistance();
                Drifting?.Invoke(lapDistance);

                if (lapDistance >= maxDistance)
                {
                    CircleIsDone();
                    this.enabled = false;
                }
            }
        }

        void CalculateDistance()
        {
            float distance = Vector3.Distance(lastPosition, tracker.position);
            lapDistance += distance;
            lastPosition = tracker.position;
        }

        public void CircleIsDone()
        {
            isDrifting = false;
            Drifting?.Invoke(0);
            lapDistance = 0;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" & !isDrifting)
            {
                NewCircle();
            }
        }

        void NewCircle()
        {
            isDrifting = true;
            lastPosition = tracker.position;
        }
    }
}
