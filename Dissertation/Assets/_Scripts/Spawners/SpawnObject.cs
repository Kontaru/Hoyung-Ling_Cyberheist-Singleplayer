using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public GameObject enemyPrefab;
    public Vector3 pos;
    public Quaternion rot;
    public bool limitReached = false;
    public int currentCount;
    public int spawnLimit;

	// Use this for initialization
	void Start () {

        pos = transform.position;
        rot = transform.rotation;
	}

    void Update()
    {
        if (spawnLimit == 0) return;
        if (currentCount >= spawnLimit)
        {
            limitReached = true;
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(15.0f);
        limitReached = false;
        currentCount = 0;
    }
}
