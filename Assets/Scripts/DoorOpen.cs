using UnityEngine;
using System.Collections;
//help from chatgpt lines 6-36
public class InteractionScript : MonoBehaviour
{
    public GameObject objectToDisable;

    private bool isCoroutineRunning = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the player is near the object and presses 'f'
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isCoroutineRunning)
            {
                StartCoroutine(DisableObjectForDuration());
            }
        }
    }

    IEnumerator DisableObjectForDuration()
    {
        isCoroutineRunning = true;

        // Disable the object
        objectToDisable.SetActive(false);

        // Wait for 10 seconds
        yield return new WaitForSeconds(6f);

        // Enable the object after 10 seconds
        objectToDisable.SetActive(true);

        isCoroutineRunning = false;
    }


}
