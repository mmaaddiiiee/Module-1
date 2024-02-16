using UnityEngine;
using TMPro;
//help chatgpt to display playerhealth in the HUD
public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    private PlayerHealth playerHealth; 

    void Start()
    {
        // Get the PlayerHealth component attached to the player GameObject
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        
        // Check if the healthText is assigned
        if (healthText == null)
        {
            Debug.LogError("Health Text is not assigned to HUD Manager!");
        }
    }

    void Update()
    {
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        if (healthText != null && playerHealth != null)
        {
            float healthPercentage = ((float)playerHealth.currentHealth / playerHealth.maxHealth) * 100f;
            healthText.text = Mathf.RoundToInt(healthPercentage) + "%";
        }
    }
}
