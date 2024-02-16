using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 
public class SnailManager : MonoBehaviour
{
    public TextMeshProUGUI snailCounterText;
    private int snailCount;

    private void Start()
    {
        snailCount = 0;
        UpdateSnailCounterText();
    }

    public void IncrementSnailCount()
    {
        snailCount++;
        UpdateSnailCounterText();

       
        if (snailCount == 3)
        {
           
            SceneManager.LoadScene("Win");
        }
    }

    
    private void UpdateSnailCounterText()
    {
        if (snailCounterText != null)
        {
            snailCounterText.text = snailCount + " out of 3";
        }
    }
}

