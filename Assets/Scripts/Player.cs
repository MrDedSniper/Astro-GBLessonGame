using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public class Player : MonoBehaviour
    {
       public float speed, turnSpeed;
       private Rigidbody2D _rigidbody;
    
       private bool _thrusting;
       private float _turnDirection;

       private int numberOfBullet = LevelingSystem.Level;

       private AudioSource _shootSound;
       
       private static ParticleSystem _levelUpAnimation;
       public ParticleSystem fireEngine;
       
       

       public static void AnimationOfLevelUp()
       {
           _levelUpAnimation.Play();
       }

       private void Awake()
       {
           _rigidbody = GetComponent<Rigidbody2D>();
           _levelUpAnimation = GetComponent<ParticleSystem>();
           _shootSound = GetComponent<AudioSource>();
       }
    
       private void Update()
       {
           _thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

           if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
           {
               _turnDirection = 1.0f;
           }
           else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
           {
               _turnDirection = -1.0f;
           }
           else
           {
               _turnDirection = 0.0f;
           }
    
           if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
           {
               Shoot();
           }
       }
    
       private void FixedUpdate()
       {
           if (_thrusting)
           {
               /*fireEngine.transform.position = gameObject.transform.position;
               fireEngine.transform.rotation = gameObject.transform.rotation;
               fireEngine.Play();*/
               
               _rigidbody.AddForce(transform.up * speed * Time.deltaTime);
           }
           
           if (_turnDirection != 0.0f)
           {
               _rigidbody.AddTorque(_turnDirection * turnSpeed * Time.deltaTime);
           }
       }
    
       private void Shoot()
       {
           _shootSound.Play();
           //Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
           //bullet.Project(transform.up);

           GameObject bullet = ObjectPool.instance.GetPooledObject();

           if (bullet != null)
           {
               bullet.transform.position = transform.position;
               bullet.transform.rotation = transform.rotation;
               bullet.SetActive(true);
           }
       }
    
       private void OnCollisionEnter2D(Collision2D col)
       {
           if (col.gameObject.tag == "Asteroid")
           {
               _rigidbody.velocity = Vector3.zero;
               _rigidbody.angularVelocity = 0.0f;
               
               gameObject.SetActive(false);

               FindObjectOfType<GameManager>().PlayerDied(); //Так делать лучше не стоит
           }
       }
    }
}