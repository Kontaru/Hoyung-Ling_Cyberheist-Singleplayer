using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour {

    public GameManager.DifficultySettings setting;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Entity>().EntityType == Entity.Entities.Player)
        {
            GameManager.instance.CurrentDifficulty = setting;
            GameManager.instance.SetDifficultyMode();
            GameManager.instance.NextScene();
        }
    }
}
