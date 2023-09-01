using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
     [SerializeField] private float turnSpeed = 4.0f;
     [SerializeField] private GameObject target;
     [SerializeField] private float minTurnAngle = -90.0f;
     [SerializeField] private float maxTurnAngle = 0.0f;

     private float rotX;
     private float targetDistance;

     void Start()
     {
          // Calculate the initial distance between the camera and the target
          targetDistance = Vector3.Distance(transform.position, target.transform.position);
     }

     void Update()
     {
          HandleRotation();
          HandlePosition();
     }

     private void HandleRotation()
     {
          // Get the mouse inputs
          float y = Input.GetAxis("Mouse X") * turnSpeed;
          rotX += Input.GetAxis("Mouse Y") * turnSpeed;

          // Clamp the vertical rotation
          rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

          // Rotate the camera
          transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
     }

     private void HandlePosition()
     {
          // Move the camera position to maintain the targetDistance
          Vector3 desiredPosition = target.transform.position - transform.forward * targetDistance;
          transform.position = desiredPosition;
     }
}
