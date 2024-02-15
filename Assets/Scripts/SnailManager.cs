using UnityEngine;
using TMPro;
//Help from Chatgpt lines 9-20
public class SnailManager : MonoBehaviour
{
    //Using TMP for Text
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
    }

    //Hud counter interacting with pickupanddestroy script

    private void UpdateSnailCounterText()
    {
        if (snailCounterText != null)
        {
            snailCounterText.text = "Snails: " + snailCount;
        }
    }
}

