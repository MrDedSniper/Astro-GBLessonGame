using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public class EnemySpawner : MonoBehaviour
    {
        public EnemyShips shipsPrefab;
        
        public float trajectoryVariance = 15.0f;
        public float spawnRate = 10.0f;
        public int spawnAmount = 1;
        public float spawnDistance = 5.0f;
        
        [SerializeField] public Transform target;

        private void Start()
        {
            InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        }

        private void Spawn()
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
                Vector3 spawnPoint = transform.position + spawnDirection;

                float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
                Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            
                EnemyShips ship = Instantiate(shipsPrefab, spawnPoint, Quaternion.identity);
                ship.SetTrajectory(transform.rotation * -spawnDirection);
            }
        }

    }
}


