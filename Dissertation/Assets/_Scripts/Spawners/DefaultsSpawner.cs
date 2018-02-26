using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultsSpawner : SpawnManager
{

    #region Typical Singleton Format

    public static DefaultsSpawner instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    #endregion

    void Update()
    {
        if (BaseEnemy.BL_allCombat) BL_CanSpawn = true;
        if (enemycount == spawnLim) BL_CanSpawn = false;
        if (CheckLimits()) BL_CanSpawn = false;

        if (BL_CanSpawn)
        {
            if (Time.time > cooldown + 7.0f)
            {
                for (int burstCount = 0; burstCount < 10; burstCount++)
                {
                    SpawnDefaults();
                    UpdateList();
                }

                cooldown = Time.time;
            }
        }
        else
        {
            cooldown = Time.time + 5.0f;
        }
    }

    //Spawn a special unit at location (using ChoosePosition();)
    protected void SpawnDefaults()
    {
        ChoosePosition();

        var enemy = (GameObject)Instantiate(current.enemyPrefab, current.pos, current.rot);
        spawnList.Add(enemy);
    }
}
