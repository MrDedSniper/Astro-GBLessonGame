using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolDrone : MonoBehaviour
{
    public static ObjectPoolDrone instanceDrone;

    private List<GameObject> pooledDroneObjects = new List<GameObject>();
    private int amountToPoolDrone = 2;

    [SerializeField] private GameObject droneBulletPrefab;
    [SerializeField] public Transform drone;

    private void Awake()
    {
        if (instanceDrone == null)
        {
            instanceDrone = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < amountToPoolDrone; i++)
        {
            GameObject droneBullet = Instantiate(droneBulletPrefab, drone.GetComponent<Transform>().position, drone.GetComponent<Transform>().rotation);
            droneBullet.SetActive(false);
            pooledDroneObjects.Add(droneBullet);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledDroneObjects.Count; i++)
        {
            if (!pooledDroneObjects[i].activeInHierarchy)
            {
                return pooledDroneObjects[i];
            }
        }

        return null;
    }
}
