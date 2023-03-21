using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float speed = 20.0f;
    //public float maxLifetime = 10.0f;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.up * speed; 
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        gameObject.SetActive(false);
    }
}
