using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Builder : MonoBehaviour
    {
        private AudioSource _shootSound;
        //[SerializeField] public Transform player;
        private Transform _player;

        private void Awake()
        {
            _shootSound = GetComponent<AudioSource>();
            _player = gameObject.transform;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                BuildBullet();
            }
        }

        private void BuildBullet()
        {
            _shootSound.Play();

            GameObject bullet = ObjectPool.instance.GetPooledObject();

            if (bullet != null)
            {
                bullet.transform.position = _player.transform.position;
                bullet.transform.rotation = _player.transform.rotation;
                bullet.SetActive(true);
            }
        }
    }
}

