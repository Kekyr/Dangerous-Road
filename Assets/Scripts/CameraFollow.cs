using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.0001f;

    private Vector3 cameraVelocity = Vector3.zero;
    private Vector3 CameraNewPosition;

    private void Start()
    {
        target = FindObjectOfType<VanMovement>().transform;
    }
    
    private void FixedUpdate()
    {
        HandleTranslation();
    }

    private void HandleTranslation()
    {
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity,smoothTime);

    }
}
