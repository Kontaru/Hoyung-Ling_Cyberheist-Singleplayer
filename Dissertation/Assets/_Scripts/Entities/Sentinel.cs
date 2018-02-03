using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Sentinel : BaseEnemy {

	// Use this for initialization
	override public void Start () {

        base.Start();
        BL_startAsCombat = true;
        CurrentState = State.Hunt;
	}

    public override void FireBullet()
    {
        base.FireBullet();

        Instantiate(go_projectilePrefab, transform.position + transform.TransformDirection(new Vector3(1, 1, 1.5F)), transform.rotation);

        Instantiate(go_projectilePrefab, transform.position + transform.TransformDirection(new Vector3(-1, 1, 1.5F)), transform.rotation);
    }
}
