using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolEnemy : MonoBehaviour
{
    public static ObjectPoolEnemy instanceEnemy;

    private List<GameObject> pooledEnemyObjects = new List<GameObject>();
    private int amountToPoolDrone = 20;

    [SerializeField] private GameObject enemyBulletPrefab;
    [SerializeField] public Transform enemy;

    private void Awake()
    {
        if (instanceEnemy == null)
        {
            instanceEnemy = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < amountToPoolDrone; i++)
        {
            GameObject enemyBullet = Instantiate(enemyBulletPrefab, enemy.GetComponent<Transform>().position, enemy.GetComponent<Transform>().rotation);
            enemyBullet.SetActive(false);
            pooledEnemyObjects.Add(enemyBullet);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledEnemyObjects.Count; i++)
        {
            if (!pooledEnemyObjects[i].activeInHierarchy)
            {
                return pooledEnemyObjects[i];
            }
        }

        return null;
    }
}
