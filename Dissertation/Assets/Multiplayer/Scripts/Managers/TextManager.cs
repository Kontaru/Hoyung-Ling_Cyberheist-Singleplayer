using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TextManager : MonoBehaviour {

    public Dialogue[] dialogues;

    public static TextManager instance;

    // Use this for initialization
    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

        // Use this for initialization
    void Start()
    {
        // Make sure there this a text
        // file assigned before continuing
    }

    public string PrintText(string name)
    {
        Dialogue d = Array.Find(dialogues, dialogue => dialogue.name == name);
        if (d == null)
        {
            Debug.LogWarning("Text: " + name + " not found!");
            return null;
        }
        string dialogLines = d.textAsset.text;
        return dialogLines;
    }
}
