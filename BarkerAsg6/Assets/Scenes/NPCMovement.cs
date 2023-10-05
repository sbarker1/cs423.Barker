using UnityEngine;

public class NPCMovement : MonoBehaviour
{
     private Transform playerTransform;
     public float minDistanceToPlayer = 5.0f;
     public float moveSpeed = 2.0f;
     public float rotationSpeed = 2.0f;
     public float wanderTime = 3.0f;

     private Vector3 randomDestination;
     private float wanderTimer = 0.0f;
     private Vector3 groundPlanePosition;

     private void Start()
     {
          playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
          groundPlanePosition = new Vector3(-0.08f, -0.4f, 0f);
          SetRandomDestination();
     }

     private void Update()
     {
          Vector3 moveDirection = transform.position - playerTransform.position;
          float distanceToPlayer = moveDirection.magnitude;

          if (distanceToPlayer < minDistanceToPlayer)
          {
               Quaternion newRotation = Quaternion.LookRotation(moveDirection);
               transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);

               Vector3 newPosition = transform.position + transform.forward * moveSpeed * Time.deltaTime;
               newPosition.y = groundPlanePosition.y;
               transform.position = newPosition;
          }
          else
          {
               // Check for obstacles
               if (CheckForObstacles())
               {
                    SetRandomDestination(); // Avoiding obstacle, change destination
               }

               if (wanderTimer < wanderTime)
               {
                    Vector3 newPosition = Vector3.MoveTowards(transform.position, randomDestination, moveSpeed * Time.deltaTime);
                    newPosition.y = groundPlanePosition.y;
                    transform.position = newPosition;
                    wanderTimer += Time.deltaTime;
               }
               else
               {
                    SetRandomDestination();
                    wanderTimer = 0.0f;
               }
          }
     }

     private void SetRandomDestination()
     {
          float randomX = Random.Range(groundPlanePosition.x - 5.0f, groundPlanePosition.x + 5.0f);
          float randomZ = Random.Range(groundPlanePosition.z - 5.0f, groundPlanePosition.z + 5.0f);
          randomDestination = new Vector3(randomX, groundPlanePosition.y, randomZ);
     }

     private bool CheckForObstacles()
     {
          RaycastHit hit;
          // Cast a ray forward to check for obstacles
          if (Physics.Raycast(transform.position, transform.forward, out hit, minDistanceToPlayer))
          {
               Debug.Log("Raycast hit: " + hit.collider.name); // Log the name of the hit object
               if (hit.collider.CompareTag("Wall"))
               {
                    Debug.Log("Wall detected");
                    // Obstacle detected (wall), return true
                    return true;
               }
          }
          return false; // No obstacles detected
     }


}
