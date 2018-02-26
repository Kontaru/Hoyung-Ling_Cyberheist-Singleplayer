using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public GameObject enemyPrefab;
    public Vector3 pos;
    public Quaternion rot;

    public enum Type
    {
        Starter,
        Basic,
        Sentinel,
    }

    public Type enemyType;

    [Header("Delayed Spawning")]
    public bool BL_hasSpawned = false;
    public bool BL_delayMySpawn = false;
    public bool BL_spawnOnce = false;
    public float FL_spawnDelay = 15.0f;

	// Use this for initialization
	void Start () {

        if (enemyType == Type.Starter)
            StartersSpawner.instance.spawns.Add(this);
        else if (enemyType == Type.Basic)
            DefaultsSpawner.instance.spawns.Add(this);
        else
            SpecialsSpawner.instance.spawns.Add(this);

        pos = transform.position;
        rot = transform.rotation;
	}

    void Update()
    {
        if (BL_delayMySpawn && BL_hasSpawned && !BL_spawnOnce)
            StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(FL_spawnDelay);
        BL_hasSpawned = false;
    }
}
