using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [Header("Entities")]

    public GameObject[] GO_Player = new GameObject[2];

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

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    #region ~ Scene Related ~

    IEnumerator PauseGame(float delay)
    {
        Time.timeScale = 0;
        yield return new WaitForSeconds(delay);
        Time.timeScale = 1;
    }
    #endregion
}
