using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    public class UISystem : MonoBehaviour
    {
        [SerializeField] Text lifeCounterText;
        [SerializeField] Text scoreCounterText;
        [SerializeField] Text levelCounterText;
        
        private void Update()
        {
           lifeCounterText.text = GameManager.lives.ToString();
           string formattedScore = Asteroids.LevelingSystem.FormatScore(GameManager.score);
           scoreCounterText.text = formattedScore;

           levelCounterText.text = LevelingSystem.Level.ToString();

           
        }
    }
}

