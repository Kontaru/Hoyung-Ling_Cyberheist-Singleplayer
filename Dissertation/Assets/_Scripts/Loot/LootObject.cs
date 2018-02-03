using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootObject : MonoBehaviour {

    public GameObject lootPrefab;
    public Vector3 pos;
    public Quaternion rot;
    public bool limitReached = false;
    public int currentCount;
    public int spawnLimit;

    public bool mainLoot;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        rot = transform.rotation;
    }

    void Update()
    {
        if (spawnLimit == 0) return;
        if (currentCount >= spawnLimit)
        {
            limitReached = true;
        }
    }
}
