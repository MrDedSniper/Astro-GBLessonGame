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
           scoreCounterText.text = GameManager.score.ToString();
           levelCounterText.text = LevelingSystem.Level.ToString();
        }
    }
}

