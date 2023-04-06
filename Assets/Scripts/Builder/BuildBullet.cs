using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;

    public void Build()
    {
        Bullet2 bullet = bulletPrefab.GetComponent<Bullet2>();
        bullet.speed = bulletSpeed;
        
    }
    
    public void BulletBuilder(Transform spawnPoint, Vector2 direction)
    {
        GameObject bulletObject = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        Bullet2 bullet = bulletObject.GetComponent<Bullet2>();
        bullet.speed = bulletSpeed;
        
    }
}
