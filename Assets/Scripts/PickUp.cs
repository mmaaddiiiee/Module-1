using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailPickup : MonoBehaviour
{
    public SnailManager snailManager; // Assign the reference to the CoinManager script in the Unity Editor

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          
            if (snailManager != null)
            {
                snailManager.IncrementSnailCount();
            }
            

            
            Destroy(gameObject);
        }
    }
}

