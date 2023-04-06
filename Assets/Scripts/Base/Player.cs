using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
       
       private static ParticleSystem _levelUpAnimation;
       
       private PlayerJump playerJump;

       public static void AnimationOfLevelUp()
       {
           _levelUpAnimation.Play();
       }

       private void Awake()
       {
           _rigidbody = GetComponent<Rigidbody2D>();
           _levelUpAnimation = GetComponent<ParticleSystem>();
       }
       
       private void Start()
       {
           playerJump = GetComponent<PlayerJump>();
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
           else if (Input.GetKeyDown(KeyCode.Space))
           {
               playerJump.Jump();
           }
           else
           {
               _turnDirection = 0.0f;
           }
       }
       private void FixedUpdate()
       {
           if (_thrusting)
           {
               _rigidbody.AddForce(transform.up * speed * Time.deltaTime);
           }
           
           if (_turnDirection != 0.0f)
           {
               _rigidbody.AddTorque(_turnDirection * turnSpeed * Time.deltaTime);
           }
       }
       private void OnCollisionEnter2D(Collision2D col)
       {
           if (col.gameObject.tag == "Enemy")
           {
               _rigidbody.velocity = Vector3.zero;
               _rigidbody.angularVelocity = 0.0f;
               
               gameObject.SetActive(false);

               FindObjectOfType<GameManager>().PlayerDied(); //Так делать лучше не стоит
           }
       }
    }
}