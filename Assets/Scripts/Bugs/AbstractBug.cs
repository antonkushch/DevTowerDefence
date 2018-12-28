using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class AbstractBug : MonoBehaviour
    {
        public int rank;
        public float startHealth;
        public float health;
        public float startSpeed;
        public float speed;
        public int reward;
        public Image healthBar;
        public float rotationSpeed = 4f;

        public List<bool> coroutineRunning = new List<bool>();

        public GameObject bugDeathEffect;

        private IMovement<AbstractBug> movement;

        void Awake()
        {
            movement = GetComponent<IMovement<AbstractBug>>();
        }

        void Update()
        {
            if (movement != null)
            {
                movement.Move(this);
            }
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            healthBar.fillAmount = health / startHealth;

            if(health <= 0)
            {
                PlayerStuff.IncrementEnemiesKilled();
                Die();
            }
        }

        public bool IsSlowedDown()
        {
            var trues = coroutineRunning.Count(x => x == true);
            var falses = coroutineRunning.Count(x => x == false);
            return !(trues == falses);
        }

        public void RestoreSpeed()
        {
            speed = startSpeed;
        }

        private void Die()
        {
            PlayerStuff.AddMoney(reward);

            var deathEffect = Instantiate(bugDeathEffect, transform.position, Quaternion.identity);
            Destroy(deathEffect, 3f);

            Destroy(gameObject);
        }
    }
}
