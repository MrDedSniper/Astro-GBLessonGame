using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Asteroids;

public class KillingObserver : MonoBehaviour
{
    [SerializeField] private Text enemyKillsText;
    
    private int enemyKillsCounter;
    private GameObject asteroid;
    private void Start()
    {
        GameManager subject = FindObjectOfType<GameManager>();
        subject.NotifyObserversEvent += HandleEvent;
        enemyKillsCounter = 0;
    }
    
    private void HandleEvent()
    {
        enemyKillsCounter++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        enemyKillsText.text = enemyKillsCounter.ToString();
    }
}