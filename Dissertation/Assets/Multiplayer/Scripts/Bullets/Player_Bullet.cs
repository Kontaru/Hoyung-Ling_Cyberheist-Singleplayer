using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : Bullet
{

    //---------------------------------------------------------------------------
    //----- Player bullet: only hurts enemies
    //---------------------------------------------------------------------------

    //Inherited method
    override public void SendDamage(Collider coll)
    {
        //If there is a collider
        if (coll != null)
        {
            if (coll.gameObject.GetComponent<Entity>() != null)
            {
                //If the collider is a generic enemy
                if (coll.gameObject.GetComponent<Entity>().EntityType == Entity.Entities.Enemy)
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
            Debug.Log("PC Bullet: Outside Loop");
            Destroy(gameObject);
        }
    }
}
