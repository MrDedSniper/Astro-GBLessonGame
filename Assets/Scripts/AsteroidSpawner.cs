using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public class AsteroidSpawner : MonoBehaviour
    {

        public Asteroid asteroidPrefab;
        public float trajectoryVariance = 15.0f;
        public float spawnRate = 0.0f;
        public int spawnAmount = 1;
        public float spawnDistance = 15.0f;
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
            
                Asteroid asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);
                asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
                asteroid.SetTrajectory(rotation * -spawnDirection);
            }
        }
    }
}

