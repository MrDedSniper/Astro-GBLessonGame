using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mediator 
{
    private UIManager uiManager;

    public Mediator(UIManager uiManager) 
    {
        this.uiManager = uiManager;
    }

    public void OnShipDestroyed() 
    {
        uiManager.ShowMessage("Ship destroyed!");
    }
}