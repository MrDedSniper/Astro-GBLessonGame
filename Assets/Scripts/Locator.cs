using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locator : MonoBehaviour
{
    public GameObject locator;
    private ObjectPool _bulletPool;

    void Start()
    {
        _bulletPool = locator.GetComponent<ObjectPool>();
    }

    void Update()
    {
        GameObject bullet = _bulletPool.GetPooledObject();
    }
}
