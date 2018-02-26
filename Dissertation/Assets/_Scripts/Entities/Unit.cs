using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : BaseEnemy
{
    override public void Start()
    {
        base.Start();
    }

    public override void Idle()
    {
        base.Idle();

        if (Vector3.Distance(transform.position, V_Home) > 0.1)
            nav_Agent.destination = V_Home;
    }

}
