using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 10;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] public Transform player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    private void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject droneBullet = Instantiate(bulletPrefab, player.GetComponent<Transform>().position, player.GetComponent<Transform>().rotation);
            droneBullet.SetActive(false);
            pooledObjects.Add(droneBullet);
        }
    }
    
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        

        return null;
    }
}

