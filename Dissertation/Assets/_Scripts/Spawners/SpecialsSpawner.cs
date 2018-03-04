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

    public float delay = 2.0f;

    public int enemiesPerSpawn = 1;

    void Update()
    {
        UpdateList();
        if (BaseEnemy.BL_allCombat) BL_CanSpawn = true;
        if (enemycount == spawnLim) BL_CanSpawn = false;
        if (CheckLimits()) BL_CanSpawn = false;

        if (BL_CanSpawn)
        {
            if (Time.time > cooldown + 5.0f)
            {
                for (int burstCount = 0; burstCount < enemiesPerSpawn; burstCount++)
                {
                    SpawnSpecials();
                }

                if (delay >= 0.0f)
                    delay -= 0.4f;
                else if (delay >= -1.0f)
                    delay -= 0.5f;
                else if (delay >= -2.0f)
                    delay -= 0.4f;
                else if (delay >= -3.0f)
                    delay -= 0.2f;


                cooldown = Time.time;
            }
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
