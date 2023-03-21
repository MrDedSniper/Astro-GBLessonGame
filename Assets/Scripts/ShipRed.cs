using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ShipRed : EnemyShips
    {
        public Bullet bulletPrefab;
        private float _rateOfFire = 3.0f;
        private void Update()
        {
            //Invoke("ShootAtPlayer", _rateOfFire);
        }

        private void ShootAtPlayer()
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}


