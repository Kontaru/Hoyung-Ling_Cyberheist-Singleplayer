using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnManager : NetworkBehaviour
{
    public static SpawnManager instance;

    public GameObject[] spawnList;
    public SpawnObject[] spawns;
    public int max_enemies = 20;
    public int enemycount = 0;
    SpawnObject current;
    SpawnObject newspawn;

    float cooldown = 0;
    bool allLimit = true;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        if (!isServer) return;

        if (enemycount == max_enemies) return;

        if (Time.time > cooldown + 5.0f)
        {
            allLimit = true;

            foreach (SpawnObject spawner in spawns)
            {
                if (spawner.limitReached == false)
                    allLimit = false;
            }

            if (allLimit == true) return;

            ChoosePosition();

            var enemy = (GameObject)Instantiate(current.enemyPrefab, current.pos, current.rot);
            enemycount++;

            for (int i = 0; i < spawnList.Length; i++)
            {
                if (spawnList[i] == null)
                    spawnList[i] = enemy;
            }

            NetworkServer.Spawn(enemy);
            cooldown = Time.time;
        }
    }

    void ChoosePosition()
    {
        newspawn = spawns[Random.Range(0, spawns.Length)];

        if (newspawn.spawnLimit != 0)
        {
            if(newspawn.limitReached)
                ChoosePosition();
        }

        if (newspawn.enemyPrefab.GetComponent<Sentinel>() != null)
        {
            if (!BaseEnemy.BL_allCombat)
                ChoosePosition();
        }

        newspawn.currentCount += 1;
        current = newspawn;
    }
}
