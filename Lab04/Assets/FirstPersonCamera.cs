using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
     [SerializeField] private float turnSpeed = 4.0f;
     [SerializeField] private float moveSpeed = 2.0f;
     [SerializeField] private float minTurnAngle = -90.0f;
     [SerializeField] private float maxTurnAngle = 90.0f;

     private float rotX;
     private float rotY;

     void Update()
     {
          MouseAiming();
          KeyboardMovement();
     }

     private void MouseAiming()
     {
          // Get the mouse inputs
          rotY = Input.GetAxis("Mouse X") * turnSpeed;
          rotX -= Input.GetAxis("Mouse Y") * turnSpeed; // Inverted Y-axis for typical FPS controls

          // Clamp the vertical rotation
          rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

          // Rotate the camera
          transform.rotation = Quaternion.Euler(rotX, rotY, 0);
     }

     private void KeyboardMovement()
     {
          Vector3 dir = new Vector3(0, 0, 0);
          dir.x = Input.GetAxis("Horizontal");
          dir.z = Input.GetAxis("Vertical");
          dir.Normalize(); // Normalize the direction vector

          // Move the camera using transform
          transform.Translate(dir * moveSpeed * Time.deltaTime);
     }
}
