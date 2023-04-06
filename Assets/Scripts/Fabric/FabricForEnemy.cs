using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy 
{
    public abstract void Attack();
    
}

public class Asteroid : Enemy 
{
    public override void Attack() 
    {
        Debug.Log("Asteroid attacked!");
    }
}

public class RedShip : Enemy 
{
    public override void Attack() 
    {
        Debug.Log("RedShip attacked!");
    }
}

public class BlueShip : Enemy 
{
    public override void Attack() 
    {
        Debug.Log("BlueShip attacked!");
    }
}

public enum EnemyType {
    Asteroid,
    RedShip,
    BlueShip
}

public class EnemyFactory {
    public static Enemy CreateEnemy(EnemyType type) {
        switch (type) {
            case EnemyType.Asteroid:
                return new Asteroid();
            case EnemyType.RedShip:
                return new RedShip();
            case EnemyType.BlueShip:
                return new BlueShip();
            default:
                throw new System.ArgumentException("Invalid enemy type");
        }
    }
}

