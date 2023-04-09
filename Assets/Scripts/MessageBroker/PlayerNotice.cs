using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerNotice : MonoBehaviour
{
    private Mediator mediator;
    public static bool isPlayerDead = false;

    private void Start() 
    {
        mediator = new Mediator(FindObjectOfType<UIManager>());
    }

    private void Update()
    {
        if (isPlayerDead)
        {
            OnDestroy();
            isPlayerDead = false;
        }
    }

    private void OnDestroy() 
    {
        mediator.OnShipDestroyed();
    }
}
