using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    public static LootManager instance;

    public GameObject[] spawnList;
    public LootObject[] spawns;
    public int max_loot = 20;
    public int lootcount = 0;
    public int acquired = 0;
    LootObject current;
    LootObject newspawn;

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

    void Start()
    {
        foreach (LootObject spawner in spawns)
        {
            if (spawner.mainLoot == true)
            {
                current = spawner;
                lootcount++;
                var loot = (GameObject)Instantiate(current.lootPrefab, current.pos, current.rot);
            }
        }

        do
        {
            allLimit = true;

            foreach (LootObject spawner in spawns)
            {
                if (spawner.limitReached == false)
                    allLimit = false;
            }

            if (allLimit == true) return;

            ChoosePosition();

            var loot = (GameObject)Instantiate(current.lootPrefab, current.pos, current.rot);
            lootcount++;

            for (int i = 0; i < spawnList.Length; i++)
            {
                if (spawnList[i] == null)
                    spawnList[i] = loot;
            }

        } while (lootcount <= max_loot);
    }

    void Update()
    {

    }

    void ChoosePosition()
    {
        newspawn = spawns[Random.Range(0, spawns.Length)];

        if (newspawn.spawnLimit != 0)
        {
            if (newspawn.limitReached)
                ChoosePosition();
        }


        newspawn.currentCount += 1;
        current = newspawn;
    }
}
