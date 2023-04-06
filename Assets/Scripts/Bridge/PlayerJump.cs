using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
   
    [SerializeField] private float JumpForce;
    public Asteroids.Builder builderScript;
    private float timer = 2f;
    

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void Jump()
    {
        rb.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
        builderScript.isJumping = true;
    }

    private void Update()
    {
        if (builderScript.isJumping)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                builderScript.isJumping = false;
                timer = 2f;
            }  
        }
    }

    
}
