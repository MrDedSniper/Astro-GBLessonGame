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
        public float speed;
        public float shieldStrength { get; set; }
        
       private float turnSpeed;
       private Rigidbody2D _rigidbody;
    
       private bool _thrusting;
       private float _turnDirection;

       private static ParticleSystem _levelUpAnimation;
       
       private PlayerJump playerJump;
       
       private ShipState _currentState = ShipState.Idle;
       
       private Player _ship;

       public static void AnimationOfLevelUp()
       {
           _levelUpAnimation.Play();
       }

       private void Awake()
       {
           _rigidbody = GetComponent<Rigidbody2D>();
           _levelUpAnimation = GetComponent<ParticleSystem>();

           speed = 60.0f;
           turnSpeed = 60.0f;
           shieldStrength = 2f;
       }

       private void Start()
       {
           playerJump = GetComponent<PlayerJump>();
           _ship = FindObjectOfType<Player>();
       }
       private void Update()
       {
           if (Input.GetKeyDown(KeyCode.W))
           {
               _ship.MoveUp();
           }
           else if (Input.GetKeyDown(KeyCode.A))
           {
               _ship.MoveLeft();
           }
           else if (Input.GetKeyDown(KeyCode.D))
           {
               _ship.MoveRight();
           }
           else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
           {
               _ship.StopMoving();
           }
           else if (Input.GetKeyDown(KeyCode.Space))
           {
               _ship.Jump();
           }
       }
       private void FixedUpdate()
       {
           switch (_currentState)
           {
               case ShipState.MovingUp:
                   _thrusting = Input.GetKey(KeyCode.W);
                   break;
               case ShipState.MovingLeft:
                   _rigidbody.AddTorque(1f * turnSpeed * Time.deltaTime);
                   break;
               case ShipState.MovingRight:
                   _rigidbody.AddTorque(-1f * turnSpeed * Time.deltaTime);
                   break;
               case ShipState.Jump:
                   playerJump.Jump();
                   break;
           }
           
           
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
       
       public void MoveUp()
       {
           _currentState = ShipState.MovingUp;
       }

       public void MoveLeft()
       {
           _currentState = ShipState.MovingLeft;
       }

       public void MoveRight()
       {
           _currentState = ShipState.MovingRight;
       }

       public void StopMoving()
       {
           _currentState = ShipState.Idle;
       }
       
       public void Jump()
       {
           _currentState = ShipState.Jump;
       }
    }
}