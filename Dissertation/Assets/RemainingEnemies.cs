using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemainingEnemies : MonoBehaviour {

    #region Typical Singleton Format

    public static RemainingEnemies instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    #endregion

    public bool waveEnd = false;
    public bool bl_LoadNext = true;

    [Header("Kills Left")]
    public TextMeshProUGUI killsRemaining;
    public int requiredCount = 2;
    public int killCount = 0;

    [Header("Time Left")]
    public TextMeshProUGUI timeRemaining;
    public float minutes = 5;
    public float currentTime = 0;
    float fl_Time = 0;
    float fl_TimeSinceLoad = 0;

    // Use this for initialization
    void Start () {
        fl_Time = minutes * 60;

        timeRemaining.text = string.Format("Time Remaining : " + Mathf.Floor(minutes) + ":00.00");
    }
	
	// Update is called once per frame
	void Update () {
        if (!BaseEnemy.BL_allCombat)
        {
            fl_TimeSinceLoad = Time.timeSinceLevelLoad;
            return;
        }
        currentTime = Time.timeSinceLevelLoad - fl_TimeSinceLoad;
		if (killCount >= requiredCount)  waveEnd = true;
        if (currentTime >= fl_Time) waveEnd = true;

        if(waveEnd && bl_LoadNext)
        {
            GameManager.instance.totalKillCount += killCount;
            GameManager.instance.NextScene();
            bl_LoadNext = false;
        }

        KillCountUIUpdater();
        TimeLeftUIUpdater();
	}

    void KillCountUIUpdater()
    {
        if(killCount <= requiredCount)
            killsRemaining.text = string.Format("Kills Remaining : " + (requiredCount - killCount));
        else if (killCount > requiredCount)
            killsRemaining.text = string.Format("Goal Achieved : " + (killCount - requiredCount));
    }

    void TimeLeftUIUpdater()
    {
        float minutes = (fl_Time - currentTime) / 60;
        float seconds = (fl_Time - currentTime) % 60;

        if (currentTime <= fl_Time)
        {
            if (seconds < 10)
            {
                timeRemaining.text = string.Format("Time Remaining : "
                    + Mathf.Floor(minutes)
                    + ":0" + seconds.ToString("F2"));
            }else
            {
                timeRemaining.text = string.Format("Time Remaining : "
                    + Mathf.Floor(minutes)
                    + ":" + seconds.ToString("F2"));
            }
        }

    }
}
