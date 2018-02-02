using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour {

    public string LeveltoLoad;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Entity>().EntityType == Entity.Entities.Player)
        {
            SceneManager.instance.LoadOnline(LeveltoLoad);
        }
    }
}
