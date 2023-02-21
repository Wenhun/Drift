using UnityEngine;

namespace Drift.CarMove
{
    public class LookToTarget : MonoBehaviour
    {
        [SerializeField] Transform target;

        void Update()
        {
            transform.LookAt(target);
        }
    }
}
