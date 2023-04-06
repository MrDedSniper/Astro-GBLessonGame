using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Asteroids;
using UnityEngine;

namespace Asteroids
{
    public class LevelingSystem : MonoBehaviour
    {
        public static int Level;
        private void Start()
        {
            Level = 1;
        }
        
        public static void GainExp()
        {
            if (GameManager.score >= 1000 * Level * 1.25)
            {
                Level++;
                Player.AnimationOfLevelUp();
            } 
        }
    }
}

