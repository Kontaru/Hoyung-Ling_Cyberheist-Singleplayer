using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public const int maxHealth = 100;

    public bool destroyOnDeath = true;

    //Calls a function whenever this value changes.
    public int currentHealth = maxHealth;
    public RectTransform healthBar;

    Vector3 defaultPos;

    private void Start()
    {
        defaultPos = transform.position;
        if(GameManager.instance.currentMode.mode != GameManager.DifficultySettings.None)
            currentHealth = (int)(currentHealth * GameManager.instance.currentMode.modEnemyHP);    
    }

    public void TakeDamage(int amount)
    {
        BaseEnemy.BL_allCombat = true;
        currentHealth -= amount;
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
        if (currentHealth <= 0)
        {
            if (destroyOnDeath)
            {
                Destroy(gameObject);
            }
            else
            {
                currentHealth = maxHealth;
                healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
                Respawn();
            }

            if (RemainingEnemies.instance != null)
            {
                RemainingEnemies.instance.killCount += 1;
            }
        }
    }

    void Respawn()
    {
        // move back to zero location
        transform.position = defaultPos;
    }

    //This is a syncvar hook. When the syncvar ever changes value, this function will be called.
    void OnChangeHealth(int health)
    {
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }
}
