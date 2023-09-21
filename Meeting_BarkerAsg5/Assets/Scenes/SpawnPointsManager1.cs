using UnityEngine;
using System.Collections.Generic;

public class SpawnPointsManager : MonoBehaviour
{
     public List<Transform> spawnPoints = new List<Transform>();

     private void Awake()
     {
         
          foreach (Transform child in transform)
          {
               spawnPoints.Add(child);
          }
     }
}
