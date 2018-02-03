using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunpickup : MonoBehaviour {

    public Weapon pickup;
    public bool respawn;

    private void OnTriggerEnter(Collider coll)
    {
        if(coll != null)
        {
            ActiveGun playerGun = coll.GetComponent<ActiveGun>();
            if (playerGun != null)
            {
                playerGun.pickup = pickup;

                if (!respawn) gameObject.SetActive(false);
            }
        }
    }
}
