using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Builder : MonoBehaviour
    {
        private AudioSource _shootSound;
        public Transform player;
        
        private IAttack _attack;
        
        //public Player player;
        
        public bool isJumping = false;

       
        public void SetAttack(IAttack attack)
        {
            _attack = attack;
        }
       
        public void SecondAttack()
        {
            NewAttack.Attack();
        }

        private void Awake()
        {
            _shootSound = GetComponent<AudioSource>();
            player = gameObject.transform;
        }

        private void Start()
        {
            BuildBullet();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !isJumping)
            {
                //SetAttack(new NewAttack());
                BuildBullet();
            }
            
            else if (Input.GetMouseButtonDown(1) && !isJumping)
            {
                SecondAttack();
            }
            
        }

        private void BuildBullet()
        {
            _shootSound.Play();

            GameObject bullet = ObjectPool.instance.GetPooledObject();

            if (bullet != null)
            {
                bullet.transform.position = player.transform.position;
                bullet.transform.rotation = player.transform.rotation;
                bullet.SetActive(true);
            }
        }
    }
}

