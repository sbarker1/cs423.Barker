using UnityEngine;

public class ArtworkInteraction : MonoBehaviour
{
     private bool isPlayerIntersecting = false;
     private Renderer artworkRenderer; 
     public Material[] artworkMaterials; 

     private SpawnPointsManager spawnPointsManager; 
     private int selectedReaction = -1; 

     private void Start()
     {
          artworkRenderer = GetComponent<Renderer>();
          spawnPointsManager = FindObjectOfType<SpawnPointsManager>();
     }

     private void OnTriggerEnter(Collider other)
     {
          if (other.CompareTag("Player"))
          {
               isPlayerIntersecting = true;

               selectedReaction = Random.Range(0, 3);

               ApplyArtworkReaction();
          }
     }

     private void OnTriggerExit(Collider other)
     {
          if (other.CompareTag("Player"))
          {
               isPlayerIntersecting = false;
          }
     }

     private void Update()
     {
          
     }

     private void ApplyArtworkReaction()
     {
          if (isPlayerIntersecting && selectedReaction != -1)
          {
               switch (selectedReaction)
               {
                    case 0:
                         Debug.Log("Artwork did nothing.");
                         break;
                    case 1:
                         Debug.Log("Artwork changed to a different picture.");
                         ChangeArtworkTexture();
                         break;
                    case 2:
                         Debug.Log("Player moved to a random location in the scene.");
                         MovePlayerToRandomLocation();
                         break;
               }
          }
     }

     private void ChangeArtworkTexture()
     {
          if (artworkMaterials.Length > 0)
          {
              
               int randomTextureIndex = Random.Range(0, artworkMaterials.Length);

               
               artworkRenderer.material = artworkMaterials[randomTextureIndex];

               Debug.Log("Artwork texture changed.");
          }
          else
          {
               Debug.LogWarning("No artwork materials assigned.");
          }
     }

     private void MovePlayerToRandomLocation()
     {
          if (spawnPointsManager != null && spawnPointsManager.spawnPoints.Count > 0)
          {
               
               int randomSpawnIndex = Random.Range(0, spawnPointsManager.spawnPoints.Count);
               Transform randomSpawnPoint = spawnPointsManager.spawnPoints[randomSpawnIndex];

               Debug.Log("Selected spawn point: " + randomSpawnPoint.name); 

               
               GameObject player = GameObject.FindGameObjectWithTag("Player");
               if (player != null)
               {
                    player.transform.position = randomSpawnPoint.position;
                    Debug.Log("Player moved to a random location.");
               }
          }
          else
          {
               Debug.LogWarning("No spawn points available.");
          }
     }
}
