using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : BaseEnemy
{

    List<Waypoint> waypoints = new List<Waypoint>();
    public float delay;
    float distance;
    int current;

    public override void Start()
    {
        base.Start();

        var possibleTargets = Physics.OverlapSphere(transform.position, 15);
        waypoints = new List<Waypoint>();
        foreach (var target in possibleTargets)
        {
            Waypoint waypoint = target.GetComponent<Waypoint>();

            if (waypoint != null)
                waypoints.Add(waypoint);
        }
        current = 0;
    }

    //Idle Mode
    override public void Idle()
    {
        base.Idle();

        if (waypoints.Count != 0)
        {
            distance = Vector3.Distance(transform.position, waypoints[current].position);

            if (distance > 2f)
            {
                nav_Agent.destination = waypoints[current].position;
                delay = Time.time + waypoints[current].stayDuration;
            }
            else if (Time.time > delay) current++;

            if (current > waypoints.Count - 1) current = 0;
        }
        else if (Vector3.Distance(transform.position, V_Home) > 0.1f) nav_Agent.destination = V_Home;
    }

    //Hunt Mode
    override public void Hunt()
    {
        nav_Agent.destination = V_Target;

        if (Vector3.Distance(transform.position, V_Target) < combatDistance) CurrentState = State.Combat;
        else if (Vector3.Distance(transform.position, V_Target) > huntDistance + 5 && !BL_startAsCombat && !BL_allCombat)
        {
            nav_Agent.destination = V_Home;

            //---

            var possibleTargets = Physics.OverlapSphere(transform.position, 15);
            waypoints = new List<Waypoint>();
            foreach (var target in possibleTargets)
            {
                Waypoint waypoint = target.GetComponent<Waypoint>();

                if (waypoint != null)
                    waypoints.Add(waypoint);
            }
            current = Random.Range(0, waypoints.Count);

            //---
            CurrentState = State.Idle;
        }
    }
}
