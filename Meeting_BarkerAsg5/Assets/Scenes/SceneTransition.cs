using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
     public string sceneToLoad; // Name of the scene to load

     private void OnTriggerEnter(Collider other)
     {
          if (other.CompareTag("Player")) // Check if the player enters the trigger zone
          {
               SceneManager.LoadScene(sceneToLoad);
          }
     }
}
