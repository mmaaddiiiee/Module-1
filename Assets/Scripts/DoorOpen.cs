using UnityEngine;
using System.Collections;
//reused from attendance assigenments.Help from cahtgpt Coroutine
public class InteractionScript : MonoBehaviour
{
    public GameObject objectToDisable;
    private bool isCoroutineRunning = false;

    void Update()
    {
        // Check if the player presses 'f'
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

        // Wait for 8 seconds
        yield return new WaitForSeconds(8f);

        // Enable the object after 8 seconds
        objectToDisable.SetActive(true);

        isCoroutineRunning = false;
    }
}
