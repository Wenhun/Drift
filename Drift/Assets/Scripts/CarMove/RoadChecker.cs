using UnityEngine;

namespace Drift.CarMove
{
    public class RoadChecker : MonoBehaviour
    {
        CarMover carMover;

        void Start()
        {
            carMover = GetComponent<CarMover>();
        }

        void OnTriggerStay(Collider other)
        {
            if (other.tag != "Plane")
            {
                carMover.enabled = false;
            }
        }
    }
}
