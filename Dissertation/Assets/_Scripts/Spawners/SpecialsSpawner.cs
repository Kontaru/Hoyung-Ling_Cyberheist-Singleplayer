using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialsSpawner : SpawnManager
{

    #region Typical Singleton Format

    public static SpecialsSpawner instance;

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
        UpdateList();
        if (BaseEnemy.BL_allCombat) BL_CanSpawn = true;
        if (enemycount == spawnLim) BL_CanSpawn = false;
        if (CheckLimits()) BL_CanSpawn = false;

        if (BL_CanSpawn)
        {
            if (Time.time > cooldown + 5.0f)
                SpawnSpecials();
        }
        else
        {
            cooldown = Time.time + 5.0f;
        }
    }

    //Spawn a special unit at location (using ChoosePosition();)
    void SpawnSpecials()
    {
        ChoosePosition();

        var enemy = (GameObject)Instantiate(current.enemyPrefab, current.pos, current.rot);
        spawnList.Add(enemy);
        cooldown = Time.time;
    }
}
