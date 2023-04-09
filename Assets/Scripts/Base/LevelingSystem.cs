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
        
        [SerializeField] private GameObject drone1;
        [SerializeField] private GameObject drone2;
        
        private void Start()
        {
            Level = 1;
        }
        
        private void Update()
        {
            if (Level == 2)
            {
                drone1.SetActive(true);
            }

            if (Level == 4)
            {
                drone2.SetActive(true);
            }
        }
        
        public static void GainExp()
        {
            if (GameManager.score >= 1000 * Level * 1.25)
            {
                Level++;
                Player.AnimationOfLevelUp();
            } 
        }

        public static string FormatScore(float score)
        {
            string suffix = "";
            float divisor = 1f;
            if (score >= 1000f && score < 1000000f)
            {
                suffix = "K";
                divisor = 1000f;
            }
            else if (score >= 1000000f)
            {
                suffix = "M";
                divisor = 1000000f;
            }
            int intValue = Mathf.FloorToInt(score / divisor);
            return intValue.ToString() + suffix;
        }
    }
}

