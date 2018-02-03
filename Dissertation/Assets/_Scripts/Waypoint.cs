using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    public float stayDuration = 0;
    public Vector3 position;

    void Start()
    {
        position = transform.position;
    }
}
