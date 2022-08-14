using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Baponkar.FPS
{
    public class Health : MonoBehaviour
    {
        public float maxHealth = 100f;
        float currentHealth;
        [HideInInspector] public bool isDead = false;
        [HideInInspector]public Slider healthSlider;
        
        void Start()
        {
            currentHealth = maxHealth;
        }

        
        void Update()
        {
            healthSlider.value = (float) currentHealth / maxHealth;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            isDead = true;
            Debug.Log("Player dead!");
        }
    }
}
