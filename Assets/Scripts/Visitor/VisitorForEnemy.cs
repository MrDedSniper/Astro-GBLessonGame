using System.Collections;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

public class VisitorForEnemy
{
    public virtual void visit(ShipRed enemyShip) 
    {
        Debug.Log("New Enemy: " + enemyShip.ToString());
    }
}
