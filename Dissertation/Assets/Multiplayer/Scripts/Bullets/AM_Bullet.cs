using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_Bullet : Bullet
{

    //---------------------------------------------------------------------------
    //----- Anti Material bullet: only hurts enemies and walls
    //---------------------------------------------------------------------------

    //Inherited method
    override public void SendDamage(Collider coll)
    {
        //If there is a collider
        if (coll != null)
        {
            if (coll.gameObject.GetComponent<BreakableWall>() != null)
            {
                coll.gameObject.SetActive(false);
            }

            if (coll.gameObject.GetComponent<Entity>() != null)
            {
                //If the collider is a generic enemy
                if (coll.gameObject.GetComponent<Entity>().EntityType == Entity.Entities.Enemy)
                {
                    //Send damage depending on what kind of enemy has been hit
                    coll.gameObject.SendMessage("TakeDamage", damage * 3, SendMessageOptions.DontRequireReceiver);
                    //Destroy the bullet
                }
            }
        }
        else
        {
            Debug.Log("PC Bullet: Outside Loop");
        }
    }
}
