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
        
        [SerializeField] public Transform target;
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();  
        }
        
        private void Update()
        {
            LookAtPlayer();
            //transform.LookAt(target);
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
            Vector3 dir = target.position - transform.position;
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    } 
}


