using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroids
{
    public class GameManager : MonoBehaviour
    {
        public Player player;
        public ParticleSystem explosion;
        
        public static int lives;
        public static int score;
        
        private float respawnTime = 3.0f;
        private float respawnInvulnerabilityTime = 3.0f;

        private void Start()
        {
            lives = 3;
            score = 0;
            LevelingSystem.Level = 0;
        }

        public void AsteroidDestroyed(Asteroid asteroid)
        {
            explosion.transform.position = asteroid.transform.position;
            explosion.Play();
    
            if (asteroid.size < 0.75f)
            {
                score += 100;
            }
            else if (asteroid.size > 1.25f)
            {
                score += 25;
            }
            else
            {
                score += 50;
            }
            
            LevelingSystem.GainExp();
        }
    
        public void PlayerDied()
        {
            explosion.transform.position = player.transform.position;
            PlayerNotice.isPlayerDead = true;
            explosion.Play();

            lives--;
    
            if (lives <= 0)
            {
                GameOver();
            }
            else
            {
                Invoke(nameof(Respawn), respawnTime);
            }
        }
        
        public void ShipDestroyed()
        {
            explosion.transform.position = player.transform.position;
            explosion.Play();
            score += 250;
        }
    
        private void Respawn()
        {
            player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollitions");
            player.transform.position = Vector3.zero;
            player.gameObject.SetActive(true);
            Invoke(nameof(TurnOnCollitions), respawnInvulnerabilityTime);
        }
    
        private void TurnOnCollitions()
        {
            player.gameObject.layer = LayerMask.NameToLayer("Player");
        }
        
        private void GameOver()
        {
            lives = 3;
            score = 0;
            
            Invoke(nameof(Respawn), respawnTime);
        }
        
        public void Restart()
        {
            lives = 3;
            score = 0;
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }

        public void GameClose()
        {
            Application.Quit();
        }
    }
}


