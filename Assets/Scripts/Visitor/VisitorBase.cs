using System.Collections;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

public class VisitorBase : MonoBehaviour
{
    void Start () 
    {
        VisitorForEnemy visitor = new VisitorForEnemy();
        ShipRed enemyShip1 = new ShipRed();
        enemyShip1.Accept(visitor);
    }
}
