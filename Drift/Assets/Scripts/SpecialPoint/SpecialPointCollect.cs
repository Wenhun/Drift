using UnityEngine;
using Drift.PointsCalculation;
using Drift.CarMove;
using System;

namespace Drift.SpecialPoint
{
    public class SpecialPointCollect : MonoBehaviour
    {
        [SerializeField] DriftTracker driftTracker;
        [SerializeField] SelectTarget selectTarget;

        float lapDistance;
        bool collectFalse = false;
        bool onPoint = false;

        SpecialPointUI specialPointUI;

        void Start()
        {
            selectTarget.newPoint += isCollect;
            specialPointUI = FindObjectOfType<SpecialPointUI>();
        }

        void OnDestroy()
        {
            selectTarget.newPoint -= isCollect;
        }

        void OnTriggerStay(Collider other)
        {
            if(other.tag == "Player")
            {
                lapDistance = driftTracker.CurrentLapDistance;
            }
        }

        void isCollect()
        {
            if(lapDistance > 0 & driftTracker.enabled & !collectFalse)
            {
                specialPointUI.FillStar();
                Destroy(gameObject);
            }
        }

        void Update()
        {
            if (lapDistance == 0 & !driftTracker.enabled & !collectFalse)
            {
                print("isNotCollect");
                collectFalse = true;
            }
        }
    }
}
