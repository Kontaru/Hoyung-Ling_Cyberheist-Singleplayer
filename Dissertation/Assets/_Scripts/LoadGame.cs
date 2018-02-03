using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour {

    public GameManager.DifficultySettings setting;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Entity>().EntityType == Entity.Entities.Player)
        {
            GameManager.instance.NextScene();
            GameManager.instance.Difficulty = setting;
        }
    }
}
