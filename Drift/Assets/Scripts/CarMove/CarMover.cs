using UnityEngine;

namespace Drift.CarMove
{
    public class CarMover : MonoBehaviour
    {
        [Header("Preferences")]
        [SerializeField] float moveSpeed = 50;
        [SerializeField] float maxSpeed = 15;
        [SerializeField] float rotationSpeed = 5.0f;
        [SerializeField] float drag = 0.98f;
        [SerializeField] float traction = 1;
        [Header("Target")]
        [SerializeField] SelectTarget target;

        Vector3 moveForce;

        void Update()
        {
            MoveCar();
            SteerCar();
            MaxSpeedLimit();
            TractionCar();
        }

        void MoveCar()
        {
            //TODO: create Range variable for "distanceThreshold"
            float distanceThreshold = 1f;
            if (Vector3.Distance(transform.position, target.GetTarget.position) >= distanceThreshold)
            {
                moveForce += transform.forward * moveSpeed * Time.deltaTime;
                transform.position += moveForce * Time.deltaTime;
            }
        }

        void SteerCar()
        {
            Vector3 direction = target.GetTarget.position - transform.position;
            direction.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        void MaxSpeedLimit()
        {
            moveForce *= drag;
            moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
        }

        void TractionCar()
        {
            moveForce = Vector3.Lerp(moveForce.normalized, transform.forward, traction * Time.deltaTime) * moveForce.magnitude;
        }
    }
}