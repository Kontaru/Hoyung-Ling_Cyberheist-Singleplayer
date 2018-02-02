using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHandles : MonoBehaviour {

    private void Update()
    {
        if (Door.instance.StartTimer)
            gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Entity>().EntityType == Entity.Entities.Player)
        {
            for (int i = 0; i < Door.instance.BL_StartTimer.Length; i++)
            {
                if (Door.instance.BL_StartTimer[0] == false)
                {
                    Door.instance.BL_StartTimer[0] = true;
                    return;
                }
            }
        }
    }
}
