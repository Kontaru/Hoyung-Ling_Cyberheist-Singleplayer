using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SceneManager : NetworkBehaviour {

    public static SceneManager instance;

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

    [ServerCallback]
    public void LoadOnline(string sceneName)
    {
        NetworkManager.singleton.ServerChangeScene(sceneName);
    }
}
