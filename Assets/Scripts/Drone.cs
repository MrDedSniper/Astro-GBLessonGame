using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private GameObject[] enemies;
    private GameObject closest;
    
    //private Transform _target;
    
    [SerializeField] private Transform bulletPosition;
    
    private float _rotationSpeed = 3.0f;
    
    private float _lastShotTime;
    private float _shootDelay = 0.2f;
    
    public Transform droneTarget;
    private Quaternion _newRotation;
    
    private float _distanceToShoot = 5.0f;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    GameObject FindClosestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector2 position = transform.position;

        foreach (GameObject go in enemies)
        {
            Vector2 diff = go.transform.position - transform.position;
            float currDistance = diff.sqrMagnitude;

            if (currDistance < distance)
            {
                closest = go;
                distance = currDistance;
            }
        }
        
        return closest;
    }
    private void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        FindClosestEnemy();
        
        if (closest)
        {
            droneTarget = closest.transform;
        }

        if (droneTarget)
        {
            LookAtEnemy();

            if (Vector2.Distance(transform.position, droneTarget.transform.position) < _distanceToShoot)
            {
                if (Time.time - _lastShotTime > _shootDelay)
                {
                    DroneShooting();
                    _lastShotTime = Time.time;
                }
            }
        }
    }

    private void DroneShooting()
    {
        GameObject droneBullet = ObjectPoolDrone.instanceDrone.GetPooledObject();

        if (droneBullet != null)
        {
            droneBullet.transform.position = transform.position;
            droneBullet.transform.rotation = transform.rotation;
            droneBullet.SetActive(true);
        }
    }

    private void LookAtEnemy()
    {
        Vector2 directionToEnemy = droneTarget.transform.position - transform.position;
        float angleToEnemy = Vector2.Angle(directionToEnemy, transform.up);
        transform.Rotate(0, 0, angleToEnemy * _rotationSpeed * Time.deltaTime);
    }
}
