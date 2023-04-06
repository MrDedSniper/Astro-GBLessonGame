using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAttack : MonoBehaviour 
{
    public static Transform _player;
        
    private void Awake()
    {
        _player = gameObject.transform;
    }
        
    public static void Attack()
    {
        GameObject bullet = ObjectPool.instance.GetPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = _player.transform.position;
            bullet.transform.rotation = _player.transform.rotation;
            bullet.SetActive(true);
        }
    }
}
