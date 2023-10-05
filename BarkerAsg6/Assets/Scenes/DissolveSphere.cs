using UnityEngine;

public class DissolveOnContact : MonoBehaviour
{
     public Renderer sphereRenderer;
     public float dissolveSpeed = 1.0f; 

     private float currentDissolveValue = 0.0f; 
     private bool isDissolving = false; 

     private void Start()
     {
          
          if (sphereRenderer != null)
          {
               sphereRenderer.material.SetFloat("_Dissolve", currentDissolveValue);
          }
     }

     private void Update()
     {
          if (isDissolving)
          {
             
               currentDissolveValue += dissolveSpeed * Time.deltaTime;

               currentDissolveValue = Mathf.Clamp01(currentDissolveValue);

               if (sphereRenderer != null)
               {
                    sphereRenderer.material.SetFloat("_Dissolve", currentDissolveValue);
               }

               if (currentDissolveValue >= 1.0f)
               {

               }
          }
     }

     private void OnTriggerEnter(Collider other)
     {
          if (other.CompareTag("Player") && !isDissolving)
          {
               isDissolving = true;
          }
     }
}
