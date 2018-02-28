using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class StatAdjustment
{
    public string name;
    public GameManager.DifficultySettings mode;
    [TextArea(2, 10)]
    public string description;
    public float modEnemyHP;
    public float modEnemyFR;
    public float modEnemyAwareness;
}

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public enum DifficultySettings
    {
        None,
        Easy,
        Medium,
        Hard,
        Intense
    }

    [Header("Loading Slider")]
    [HideInInspector] public GameObject loadingScreen;
    [HideInInspector] public Slider slider;

    [Header("Inputs")]
    public KeyCode KC_Shoot;
    public KeyCode KC_Missile;
    public KeyCode KC_Punch;

    [Header("Entities")]
    public GameObject[] GO_Player = new GameObject[2];

    [Header("Difficulty")]
    public DifficultySettings CurrentDifficulty;
    public StatAdjustment[] Modes;
    public StatAdjustment currentMode;

    public bool BL_Pause;
    public float totalKillCount;

    public float wave1Kills;
    public float wave2Kills;
    public float wave3Kills;

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

    public void SetDifficultyMode()
    {
        foreach (StatAdjustment var in Modes)
        {
            if (CurrentDifficulty == var.mode)
            {
                currentMode = var;
                return;
            }
        }
    }

    #region ~ Scene Related ~

    public void NextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            StartCoroutine(LoadAsynchronously());
        }
    }

    IEnumerator LoadAsynchronously ()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);
        operation.allowSceneActivation = false;
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;

            if (operation.progress == 0.9f)
                operation.allowSceneActivation = true;

            yield return null;
        }
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index, LoadSceneMode.Single);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        BL_Pause = !BL_Pause;

        if (BL_Pause == true)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    #endregion
}
