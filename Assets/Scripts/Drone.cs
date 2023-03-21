using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    
    private Transform _target;
    [SerializeField] private Transform bulletPosition;
    private float _angularSpeed = 10.0f;
    
    private float _nextShootTime, _shootRate = 3.0f;

    private bool _isTargetOnSight = false;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Asteroid")
        {
            _target = FindObjectOfType<Asteroids.Asteroid>().transform;
            _isTargetOnSight = true;
            
            DroneShooting();
            
           /* if (Time.deltaTime > _nextShootTime)
            {
                DroneShooting();
                _nextShootTime = Time.deltaTime + _shootRate;
            }*/
            
        }
        else if (col.gameObject.tag == "EnemyShip")
        {
            _target = FindObjectOfType<Asteroids.EnemyShips>().transform;
            _isTargetOnSight = true;
            
            DroneShooting();
        }

        else
        {
            _target = FindObjectOfType<Asteroids.Player>().transform;
        }
    }

    private void Update()
    {
        if (_isTargetOnSight)
        {
            LookAtEnemy();
        }
    }

    private void DroneShooting()
    {
        GameObject droneBullet = ObjectPool.instance.GetPooledObject();

        if (droneBullet != null)
        {
            droneBullet.transform.position = transform.position;
            droneBullet.transform.rotation = transform.rotation;
            droneBullet.SetActive(true);
        }
    }

    private void LookAtEnemy()
    {
        Vector3 dir = _target.position - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
