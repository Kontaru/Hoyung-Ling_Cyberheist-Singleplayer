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
            if (coll.gameObject == GameManager.instance.GO_Player[0] || coll.gameObject == GameManager.instance.GO_Player[1])
            {
                //Send damage depending on what kind of enemy has been hit
                coll.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
                //Destroy the bullet
                Debug.Log("Hit + " + coll.gameObject.name);
                Destroy(gameObject);
            }
        }
    }
}
