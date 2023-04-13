using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Asteroids
{
    public class ShipRed : EnemyShips
    {
        public Bullet bulletPrefab;
        
        private float _distanceToShoot = 5.0f;
        
        private float _lastShotTime;
        private float _shootDelay = 2.0f;
       
        private void Update()
        {
            if (player)
            {
                if (Vector2.Distance(transform.position, player.transform.position) < _distanceToShoot)
                {
                    if (Time.deltaTime - _lastShotTime > _shootDelay)
                    {
                        ShootAtPlayer();
                        _lastShotTime = Time.deltaTime;
                    }
                }
            }
        }
        
        private void ShootAtPlayer()
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        
        public void Accept(VisitorForEnemy visitor)
        {
           visitor.visit(this);
        }
    }
}


