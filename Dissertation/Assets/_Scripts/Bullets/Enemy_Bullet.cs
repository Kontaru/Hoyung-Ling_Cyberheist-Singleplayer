using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : Bullet
{

    //---------------------------------------------------------------------------
    //----- Enemy bullet: only hurts players
    //---------------------------------------------------------------------------

    //Inherited method
    override public void SendDamage(Collider coll)
    {
        //If there is a collider
        if (coll != null)
        {
            if (coll.gameObject.GetComponent<Entity>() != null)
            {
                //If the collider is player
                if (coll.gameObject.GetComponent<Entity>().EntityType == Entity.Entities.Player)
                {
                    //Send damage depending on what kind of enemy has been hit
                    coll.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
                    //Destroy the bullet
                    Destroy(gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.Log("Enemy Bullet: Outside Loop");
            Destroy(gameObject);
        }
    }
}
