using UnityEngine;

public class ArtworkInteraction : MonoBehaviour
{
     private bool isPlayerIntersecting = false;
     private bool canRelocatePlayer = true; // Flag to track if player can be relocated
     private Renderer artworkRenderer;
     public Material[] artworkMaterials;
     public float relocationCooldown = 2.0f; 
     private float relocationTimer = 0.0f;

     private void Start()
     {
          artworkRenderer = GetComponent<Renderer>();
     }

     private void OnTriggerEnter(Collider other)
     {
          if (other.CompareTag("Player"))
          {
               isPlayerIntersecting = true;
               UnityEngine.Debug.Log("Player entered artwork trigger zone.");

               if (canRelocatePlayer)
               {
                    canRelocatePlayer = false; // Disabling my player relocation
                    relocationTimer = 0.0f;
               }
          }
     }

     private void OnTriggerExit(Collider other)
     {
          if (other.CompareTag("Player"))
          {
               isPlayerIntersecting = false;
               UnityEngine.Debug.Log("Player exited artwork trigger zone.");
          }
     }

     private void Update()
     {
          if (isPlayerIntersecting)
          {
               relocationTimer += Time.deltaTime; 

               if (relocationTimer >= relocationCooldown)
               {
                    canRelocatePlayer = true; //Enable my player relocation after cooldown
               }

               if (canRelocatePlayer)
               {
                    // Implement random artwork reactions here
                    int randomReaction = UnityEngine.Random.Range(0, 3);

                    switch (randomReaction)
                    {
                         case 0:
                              UnityEngine.Debug.Log("Artwork did nothing.");
                              break;
                         case 1:
                              UnityEngine.Debug.Log("Artwork changed to a different picture.");
                              ChangeArtworkTexture();
                              break;
                         case 2:
                              UnityEngine.Debug.Log("Player moved to a random location in the scene.");
                              MovePlayerToRandomLocation();
                              relocationTimer = 0.0f; //Reset relocation timer
                              break;
                    }

                    canRelocatePlayer = false; //Disable my player relocation after triggering
               }
          }
     }

     private void ChangeArtworkTexture()
     {
          if (artworkMaterials.Length > 0)
          {
               int randomTextureIndex = UnityEngine.Random.Range(0, artworkMaterials.Length);
               artworkRenderer.material = artworkMaterials[randomTextureIndex];
               UnityEngine.Debug.Log("Artwork texture changed.");
          }
          else
          {
               UnityEngine.Debug.LogWarning("No artwork materials assigned.");
          }
     }

     private void MovePlayerToRandomLocation()
     {
          float minX = -10f;
          float maxX = 10f;
          float minY = 0f;
          float maxY = 5f;
          float minZ = -10f;
          float maxZ = 10f;

          float randomX = UnityEngine.Random.Range(minX, maxX);
          float randomY = UnityEngine.Random.Range(minY, maxY);
          float randomZ = UnityEngine.Random.Range(minZ, maxZ);

          Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

          GameObject player = GameObject.FindGameObjectWithTag("Player");

          if (player != null)
          {
               player.transform.position = randomPosition;
          }
          else
          {
               UnityEngine.Debug.LogWarning("Player GameObject not found.");
          }

          UnityEngine.Debug.Log("Player moved to a random location.");
     }
}
