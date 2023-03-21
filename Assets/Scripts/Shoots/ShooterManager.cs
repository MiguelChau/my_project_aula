using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterManager : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> pooledOfObjects;

    public int amount = 1000;

    private void Awake()
    {
        StartPool();
    }
    private void StartPool()
    {
        pooledOfObjects = new List<GameObject>();
        for (int c = 0; c < amount; c++)
        {
            var obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            pooledOfObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int c = 0; c < amount; c++)
        {
            if (!pooledOfObjects[c].activeInHierarchy)
            {
                return pooledOfObjects[c];
            }
        }
        return null;
    }
}

