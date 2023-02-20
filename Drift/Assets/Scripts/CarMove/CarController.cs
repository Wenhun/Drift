using System;
using System.Collections.Generic;
using UnityEngine;

public enum Axel
{
    Front,
    Rear
}

[Serializable]
public struct Wheel
{
    public GameObject model;
    public WheelCollider collider;
    public Axel axel;
}

public enum DriveTrain
{
    Four_Wheel,
    Two_Wheel
}

public class CarController : MonoBehaviour
{
    [SerializeField] float maxSpeed = 100f;
    [SerializeField] float acceleration = 20f;
    //[SerializeField] float turnSensitivity = 1f;
    [SerializeField] float maxSteerAngle = 45f;
    [SerializeField] Vector3 _centerOfMass;
    [SerializeField] DriveTrain driveTrain;
    [SerializeField] List<Wheel> wheels;
    [SerializeField] Transform target;

    float inputX, addForce;

    Rigidbody rb;

    bool shouldApplyForceToWheels = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = _centerOfMass;
    }

    void Update()
    {
        AnimateWheels();
        GetInput();//debug method
        MoveToPoint();
        CheckDrift();
    }

    void MoveToPoint()
    {
        float distanceThreshold = 0.5f;
        if (Vector3.Distance(transform.position, target.position) <= distanceThreshold)
        {
            addForce = 0;
        }
        else
        {
            addForce = 1f;
        }
    }

    void AnimateWheels()
    {
        foreach(var wheel in wheels)
        {
            Quaternion _rot;
            Vector3 _pos;
            wheel.collider.GetWorldPose(out _pos, out _rot);
            wheel.model.transform.position = _pos;
            wheel.model.transform.rotation = _rot;
        }
    }

    void GetInput()
    {
        inputX = Input.GetAxis("Horizontal");
        addForce = Input.GetAxis("Vertical");
    }

    void LateUpdate()
    {
        ApplyForceToWheels();
        TurnWheels();
    }

    void ApplyForceToWheels()
    {
        float currentSpeed = rb.velocity.sqrMagnitude;
        if (currentSpeed > maxSpeed) return;
        if (shouldApplyForceToWheels == false) return;


        foreach(var wheel in wheels)
        {
            if (wheel.axel == Axel.Front & driveTrain == DriveTrain.Four_Wheel)
            {
                wheel.collider.motorTorque = addForce * acceleration;

            }
            else if (wheel.axel == Axel.Rear)
            {
                wheel.collider.motorTorque = addForce * acceleration ;
            }
        }
    } 

    void TurnWheels()
    {
        foreach(var wheel in wheels)
        {
            if(wheel.axel == Axel.Front)
            {
                float angle = CalculateAngle();
                var _steerAngle = Mathf.Clamp(-angle, -maxSteerAngle, maxSteerAngle);
                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, _steerAngle, 0.5f);
            }
        }
    }    
    
    float CalculateAngle()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        Vector3 cross = Vector3.Cross(direction, transform.forward);
        if (cross.y < 0) angle = -angle;

        return angle;
    }

    void CheckDrift()
    {
        float driftValue = Vector3.Dot(rb.velocity.normalized, transform.forward.normalized);
        float driftAngle = Mathf.Acos(driftValue) * Mathf.Rad2Deg;
        if (driftAngle > 30 & rb.velocity.sqrMagnitude > maxSpeed / 2)
        {
            shouldApplyForceToWheels = false;
        }
        else
        {
            shouldApplyForceToWheels = true;
        }
    }
}
