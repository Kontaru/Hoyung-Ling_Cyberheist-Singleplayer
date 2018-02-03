using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour {

    public bool mainloot = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Entity>().EntityType == Entity.Entities.Player)
        {

            //if(mainloot == true)
            //{
            //    SceneManager.instance.LoadOnline("_End");
            //}
            LootManager.instance.acquired++;
            gameObject.SetActive(false);
        }
    }
}
