using System.Collections.Generic;
using UnityEngine;
//I prompted chatgpt to use my existing code from a previous attendance assignment to create this one
//and add a way for me to list and input into the inspector the specific collectble locations
//this script used randomize in a different way than my other assignment since
//This randomized which collectables would spawn and used a shuffle function
public class RandomCollectManager : MonoBehaviour
{
    public List<GameObject> collectibles; 
    public int numberOfObjectsToEnable = 5; 

    private void Start()
    {
        EnableRandomCollectibles();
    }

    private void EnableRandomCollectibles()
    {
        // Shuffle the list of collectibles
        Shuffle(collectibles);

        // Enable a certain number of collectibles
        for (int i = 0; i < Mathf.Min(numberOfObjectsToEnable, collectibles.Count); i++)
        {
            collectibles[i].SetActive(true);
        }
    }

    // Fisher-Yates shuffle algorithm to shuffle the list
    private void Shuffle(List<GameObject> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            GameObject value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}

