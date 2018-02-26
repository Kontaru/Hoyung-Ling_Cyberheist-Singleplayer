using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartersSpawner : SpawnManager {

    #region Typical Singleton Format

    public static StartersSpawner instance;

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

    // Use this for initialization
    void Start () {
        StartCoroutine(LateSpawn());
	}
	
	// Update is called once per frame
	void Update () {
        UpdateList();
	}

    IEnumerator LateSpawn()
    {
        for (int i = 0; i < spawns.Count; i++)
        {
            var temp = spawns[i];
            int randomIndex = Random.Range(i, spawns.Count);
            spawns[i] = spawns[randomIndex];
            spawns[randomIndex] = temp;
        }

        yield return new WaitForSeconds(0.1f);
        foreach (var item in spawns)
        {
            if (enemycount == spawnLim) break;

            current = item;
            var enemy = (GameObject)Instantiate(current.enemyPrefab, current.pos, current.rot);
            spawnList.Add(enemy);

            enemycount = spawnList.Count;
        }
    }
}
