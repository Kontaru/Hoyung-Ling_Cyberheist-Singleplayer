using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gunpickup : MonoBehaviour {

    public Weapon pickup;
    public bool respawn;
    public float respawnDelay;
    bool acquired = false;

    public TextMeshProUGUI Timer;

    private void Start()
    {
        float minutes = (respawnDelay) / 60;
        if (Timer != null)
            Timer.text = string.Format("" + Mathf.Floor(minutes) + ":00.00");
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(!acquired && coll != null)
        {
            ActiveGun playerGun = coll.GetComponent<ActiveGun>();
            if (playerGun != null)
            {
                playerGun.pickup = pickup;

                transform.GetChild(0).gameObject.SetActive(false);
                acquired = true;
                if (respawn) StartCoroutine(RespawnDelay());
            }
        }
    }

    IEnumerator RespawnDelay()
    {
        float start = Time.timeSinceLevelLoad;
        while (Time.timeSinceLevelLoad < start + respawnDelay)
        {
            float fl_Time = start + respawnDelay;
            if (Timer != null)
            {
                float minutes = (fl_Time - Time.timeSinceLevelLoad) / 60;
                float seconds = (fl_Time - Time.timeSinceLevelLoad) % 60;

                if (seconds < 10)
                {
                    Timer.text = string.Format(""
                    + Mathf.Floor(minutes)
                    + ":0" + seconds.ToString("F2"));
                }
                else
                {
                    Timer.text = string.Format(""
                    + Mathf.Floor(minutes)
                    + ":" + seconds.ToString("F2"));
                }
            }
            yield return null;
        }

        transform.GetChild(0).gameObject.SetActive(true);
        acquired = false;
    }
}
