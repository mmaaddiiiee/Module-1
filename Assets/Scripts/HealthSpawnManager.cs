using System.Collections.Generic;
using UnityEngine;
//Help from chatgpt to create this script. 
//I had to combine some elements from multiple scripts and
// prompts to get the health packs to randomly spawn and also use pooling.
//when trying to combien script it was giving me a lot of errors so I used chatgpt to help.
public class HealthSpawnManager : MonoBehaviour
{
    
    public GameObject healthPackPrefab; 
    public int numberOfHealthPacksToSpawn; 
    public GameObject spawnAreaConstraint; 
    public bool spawnOnStart = true; 
    private string terrainTag = "Terrain";

    private List<GameObject> objectPool = new List<GameObject>();
    private List<GameObject> healthPackPool = new List<GameObject>();

    private void Start()
    {
        if (spawnOnStart)
        {
            InitializeObjectPool();
            InitializeHealthPackPool();
            SpawnObjects();
            SpawnHealthPacks();
        }
    }

    private void InitializeObjectPool()
    {
        
    }

    private void InitializeHealthPackPool()
    {
        for (int i = 0; i < numberOfHealthPacksToSpawn; i++)
        {
            GameObject healthPack = Instantiate(healthPackPrefab, transform.position, Quaternion.identity);
            healthPack.SetActive(false);
            healthPackPool.Add(healthPack);
        }
    }

    public void SpawnObjects()
    {
       
        {
            GameObject obj = GetPooledObject(objectPool);
            if (obj != null)
            {
                obj.transform.position = GetRandomPosition();
                obj.SetActive(true);
            }
        }
    }

    public void SpawnHealthPacks()
    {
        for (int i = 0; i < numberOfHealthPacksToSpawn; i++)
        {
            GameObject healthPack = GetPooledObject(healthPackPool);
            if (healthPack != null)
            {
                healthPack.transform.position = GetRandomPosition();
                healthPack.SetActive(true);
            }
        }
    }

    private GameObject GetPooledObject(List<GameObject> pool)
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;
    }

    private Vector3 GetRandomPosition()
    {
        // Calculate random position within the spawn area constraint
        Vector3 spawnAreaCenter = spawnAreaConstraint.transform.position;
        Vector3 spawnAreaSize = Vector3.Scale(spawnAreaConstraint.transform.localScale, spawnAreaConstraint.GetComponent<BoxCollider>().size);
        Vector3 randomPosition = spawnAreaCenter + new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            0f,
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2));

        // Ensure the spawned objects do not intersect with objects tagged as "Terrain"
        Collider[] hitColliders = Physics.OverlapBox(randomPosition, new Vector3(0.5f, 0.5f, 0.5f));
        foreach (Collider col in hitColliders)
        {
            if (col.gameObject.CompareTag(terrainTag))
            {
                randomPosition = GetRandomPosition();
                break;
            }
        }

        return randomPosition;
    }
}
