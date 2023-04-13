using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyShips : MonoBehaviour
    {
        public float maxLifetime = 30.0f;
        public float speed = 30.0f;
        public ParticleSystem explosion;

        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody;

        private float _rotationSpeed = 30.0f;

        public Player player;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();  
        }

        private void Start()
        {
            player = GameObject.FindObjectOfType<Player>();
        }
        private void Update()
        {
            if (player)
            {
                LookAtPlayer();
            }
        }

        public void SetTrajectory(Vector2 direction)
        {
            _rigidbody.AddForce(direction * speed);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Bullet")
            {
                FindObjectOfType<GameManager>().ShipDestroyed();
                Destroy(gameObject);
            }
        }
        
        private void LookAtPlayer()
        {
            Vector2 directionToEnemy = player.transform.position - transform.position;
            float angleToEnemy = Vector2.Angle(directionToEnemy, transform.up);
            transform.Rotate(0, 0, angleToEnemy * _rotationSpeed * Time.deltaTime);
        }

        
    }
}


