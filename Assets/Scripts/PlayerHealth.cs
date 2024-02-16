using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
//help from chatgot to implent an incremental health system that works with the HUDmanager to dispaly via HUD
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI healthText;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
        UpdateHealthText();
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Ensure health doesn't exceed maxHealth
        UpdateHealthText();
    }

    void Die()
    {
        SceneManager.LoadScene("Game Over"); // Load the game over scene
    }
}

