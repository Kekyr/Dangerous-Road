using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanMovement : MonoBehaviour
{
    [SerializeField] private WheelCollider frontRightCollider;
    [SerializeField] private WheelCollider frontLeftCollider;
    [SerializeField] private WheelCollider rearRightCollider;
    [SerializeField] private WheelCollider rearLeftCollider;

    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    private float currentBreakForce;
    public bool isBreaking;
    
    
    private void FixedUpdate()
    {
        HandleMotor();
        UpdateWheels();
    }

    private void HandleMotor()
    {
        frontLeftCollider.motorTorque = motorForce;
        frontRightCollider.motorTorque = motorForce;
    }

   

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearLeftCollider, rearLeftWheelTransform);
        UpdateSingleWheel(rearRightCollider, rearRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);
        wheelTransform.rotation = rotation;
        wheelTransform.position = position;

    }

    private void OnCollisionEnter()
    {
        Time.timeScale = 0;
    }


}
