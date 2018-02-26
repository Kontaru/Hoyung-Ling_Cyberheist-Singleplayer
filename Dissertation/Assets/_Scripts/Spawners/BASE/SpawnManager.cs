using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> spawnList;
    public List<SpawnObject> spawns;
    protected SpawnObject current;
    protected SpawnObject newspawn;

    public int spawnLim = 20;
    public int enemycount = 0;

    public bool BL_CanSpawn = false;
    protected float cooldown = 0;

    protected bool CheckLimits()
    {
        foreach (SpawnObject spawner in spawns)
        {
            if (spawner.BL_hasSpawned == false)
                return false;
        }

        return true;
    }

    protected void ChoosePosition()
    {
        newspawn = spawns[Random.Range(0, spawns.Count)];

        if (newspawn.BL_delayMySpawn)
        {
            if (newspawn.BL_hasSpawned)
                ChoosePosition();
            else
            {
                newspawn.BL_hasSpawned = true;
                current = newspawn;
            }
        }
        else
        {
            current = newspawn;
        }
    }

    //Update our spawn list to reflect any enemy deaths that have occured thus far
    protected void UpdateList()
    {
        for (int i = 0; i < spawnList.Count; i++)
        {
            if (spawnList[i] == null)
            {
                spawnList.RemoveAt(i);
            }
        }

        enemycount = spawnList.Count;
    }
}
