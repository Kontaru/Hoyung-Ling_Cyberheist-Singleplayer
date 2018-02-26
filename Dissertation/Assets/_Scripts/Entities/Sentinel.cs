using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Sentinel : BaseEnemy {

    public override void FireBullet()
    {
        base.FireBullet();

        Instantiate(go_projectilePrefab, transform.position + transform.TransformDirection(new Vector3(1, 1, 1.5F)), transform.rotation);

        Instantiate(go_projectilePrefab, transform.position + transform.TransformDirection(new Vector3(-1, 1, 1.5F)), transform.rotation);
    }
}
