using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public float speed = 10f;
    
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidBody.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        gameObject.SetActive(false);
    }
}
