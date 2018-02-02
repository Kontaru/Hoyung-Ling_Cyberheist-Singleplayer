using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PC_Health : NetworkBehaviour {

    public const int maxHealth = 100;
    private NetworkStartPosition[] spawnPoints;

    public bool destroyOnDeath = true;

    //Calls a function whenever this value changes.
    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;
    public RectTransform healthBar;

    private void Start()
    {
        if(!isLocalPlayer)
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
    }

    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }

        currentHealth -= amount;
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
        RpcRespawn();
    }

    //This command is called by the client, and tells the server to do it.
    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            // Set the spawn point to origin as a default value
            Vector3 spawnPoint = Vector3.zero;

            // If there is a spawn point array and the array is not empty, pick a spawn point at random
            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }

            // Set the player’s position to the chosen spawn point
            transform.position = spawnPoint;
        }
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
