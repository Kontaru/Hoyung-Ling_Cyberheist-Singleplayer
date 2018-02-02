using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Bullet : MonoBehaviour
{

    //---------------------------------------------------------------------------
    //----- Bullets: basic script which other bullet scripts should inherit
    //---------------------------------------------------------------------------

    //On collision with an object
    protected Rigidbody RB_Bullet;

    [Header("Bullet Variables")]
    public float speed;         //Speed of bullet
    public int damage;          //Damage of bullet
    public float killAfter;     //How long should the bullet persist for?

    [Header("Audio")]
    public string sound;

    // Use this for initialization
    void Start()
    {
        //Grab the Rigidbody component of the bullet
        RB_Bullet = GetComponent<Rigidbody>();
        //Set its velocity forward
        RB_Bullet.velocity = transform.TransformDirection(Vector3.forward) * speed;

        //Destroy after a while
        Destroy(gameObject, killAfter);

        //Play some audio
        AudioManager.instance.Play(sound);
    }

    #region Damage Sending

    //When it hits a thing
    void OnTriggerEnter(Collider coll)
    {
        //Send Damage
        SendDamage(coll);
    }

    //Abstract method for parent script
    abstract public void SendDamage(Collider coll);

    #endregion
}
