using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public TextAnimator anim;
}

public class WaveManager : MonoBehaviour {

    #region Typical Singleton Format

    public static WaveManager instance;

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

    public Wave waves;
    DefaultsSpawner defaultSpawner;
    SpecialsSpawner specialSpawner;

    // Use this for initialization
    void Start()
    {
        GrabReferences();
        DisableScripts();
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        if (waves.anim.Play == false)
        {
            EnableScripts();
        }
    }

    //Grab References
    void GrabReferences()
    {
        defaultSpawner = DefaultsSpawner.instance;
        specialSpawner = SpecialsSpawner.instance;
    }

    //Disable Scripts
    void DisableScripts()
    {
        defaultSpawner.enabled = false;
        specialSpawner.enabled = false;
    }

    //Enable Scripts
    void EnableScripts()
    {
        defaultSpawner.enabled = true;
        specialSpawner.enabled = true;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(10.0f);
        waves.anim.Play = true;
    }
}
