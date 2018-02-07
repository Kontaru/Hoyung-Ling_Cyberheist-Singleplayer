using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infrastructure : MonoBehaviour {

    public static List<Infrastructure> buildings = new List<Infrastructure>(0);

	// Use this for initialization
	void Start () {
        buildings.Add(this);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Entity>().EntityType == Entity.Entities.Player)
        {
            foreach (Infrastructure building in buildings)
            {
                if(building != this)
                {
                    building.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Entity>().EntityType == Entity.Entities.Player)
        {
            foreach (Infrastructure building in buildings)
            {
                building.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
