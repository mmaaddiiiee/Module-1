using System.Collections.Generic;
using UnityEngine;
//help from chatgpt to help me with the implementation of pooling. 
//I prompted it to use my bullet game object I already created to use pooling instead of destroying 
//pooling was hard for me to get at first, but I understand it better now
public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    public GameObject bulletPrefab;
    public int poolSize = 20;

    private List<GameObject> pooledBullets;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        pooledBullets = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            pooledBullets.Add(bullet);
        }
    }

    public GameObject GetBullet()
    {
        foreach (GameObject bullet in pooledBullets)
        {
            if (!bullet.activeInHierarchy)
                return bullet;
        }

        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.SetActive(false);
        pooledBullets.Add(newBullet);
        return newBullet;
    }
}

