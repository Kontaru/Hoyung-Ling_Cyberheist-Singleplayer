using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScoreSetter : MonoBehaviour {

    [Header("Wave 1")]
    public TextMeshProUGUI Wave1Kills;
    public TextMeshProUGUI Wave1Time;

    [Header("Wave 2")]
    public TextMeshProUGUI Wave2Kills;
    public TextMeshProUGUI Wave2Time;

    [Header("Wave 3")]
    public TextMeshProUGUI Wave3Kills;
    public TextMeshProUGUI Wave3Time;

    // Use this for initialization
    void Start () {

        Wave1Kills.text = string.Format(GameManager.instance.wave1Kills.ToString());
        Wave2Kills.text = string.Format(GameManager.instance.wave2Kills.ToString());
        Wave3Kills.text = string.Format(GameManager.instance.wave3Kills.ToString());

        Wave1Time.text = string.Format(GameManager.instance.wave1Time.ToString());
        Wave2Time.text = string.Format(GameManager.instance.wave2Time.ToString());
        Wave3Time.text = string.Format(GameManager.instance.wave3Time.ToString());

    }
}
