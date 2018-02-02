using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour {

    public static Door instance;
    public bool[] BL_StartTimer = new bool[2];
    public TextMeshProUGUI Timer;

    public bool StartTimer = false;
    public float duration = 60.0f;
    float overheadTimer = 0f;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        overheadTimer = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (BL_StartTimer[0] && BL_StartTimer[1])
        {
            StartTimer = true;
        }

        if (StartTimer)
        {
            StartCoroutine(CloseDoor());
            overheadTimer -= Time.deltaTime;
            Timer.text = string.Format("" + overheadTimer);
        }
    }

    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }
}
