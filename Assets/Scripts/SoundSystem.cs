using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Asteroids
{
    public class SoundSystem : MonoBehaviour
    {
        [SerializeField] public AudioSource shootSound;
        [SerializeField] public AudioSource deathSound;
        

        private void Start()
        {
            shootSound = GetComponent<AudioSource>();
            deathSound = GetComponent<AudioSource>();
        }
        
        
    } 
}

