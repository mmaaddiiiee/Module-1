using UnityEngine;
//help from chatgpt. Had to get this script to work with the HealthSpawnManagera
public class HealthPack : MonoBehaviour
{
    public int healthToAdd = 25; 

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            
            if (playerHealth != null)
            {
                playerHealth.Heal(healthToAdd);
                Destroy(gameObject); 
            }
        }
    }
}

