using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Loot : NetworkBehaviour {

    public bool mainloot = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Entity>().EntityType == Entity.Entities.Player)
        {
            if(mainloot == true)
            {
                SceneManager.instance.LoadOnline("_End");
            }
            LootManager.instance.acquired++;
            gameObject.SetActive(false);
        }
    }
}
