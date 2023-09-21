using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     public float speed = 12f;

     // Remove the 'public Transform playerStartPosition;' line
     // We'll assume the player's start position is where the GameObject is in the scene

     private CharacterController characterController;

     // Start is called before the first frame update
     void Start()
     {
          characterController = GetComponent<CharacterController>();
          Cursor.lockState = CursorLockMode.Locked;
     }

     // Update is called once per frame
     void Update()
     {
          float x = Input.GetAxis("Horizontal");
          float z = Input.GetAxis("Vertical");

          Vector3 move = transform.right * x + transform.forward * z;

          characterController.Move(move * speed * Time.deltaTime);

          // Assuming your MouseLook script is attached to the same GameObject
          // and takes care of camera rotation
     }
}
