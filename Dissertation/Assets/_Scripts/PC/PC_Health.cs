using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PC_Health : MonoBehaviour {

    public const int maxHealth = 100;

    public bool destroyOnDeath = true;

    //Calls a function whenever this value changes.
    public int currentHealth = maxHealth;
    public RectTransform healthBar;

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.sizeDelta = new Vector2(currentHealth * 4, healthBar.sizeDelta.y);
        if (currentHealth <= 0)
        {
            if (destroyOnDeath)
            {
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(Respawn());
            }

        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2.0f);
        currentHealth = maxHealth;
        // Set the spawn point to origin as a default value
        Vector3 spawnPoint = Vector3.zero;

        //// If there is a spawn point array and the array is not empty, pick a spawn point at random
        //if (spawnPoints != null && spawnPoints.Length > 0)
        //{
        //    spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        //}

        // Set the player’s position to the chosen spawn point
        transform.position = spawnPoint;
    }

    //This is a syncvar hook. When the syncvar ever changes value, this function will be called.
    void OnChangeHealth(int health)
    {
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }

    void TakeHealth(int heal)
    {
        currentHealth += heal;
        AudioManager.instance.Play("Heal");
    }
}
