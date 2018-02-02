using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ScriptCollector
{
    public string Target_dialogue_name;
    public string dialogueLines;

    public ScriptCollector()
    {
        Target_dialogue_name = "Fill me!";
        dialogueLines = "Fill me!";
    }

    public ScriptCollector(string name, string script)
    {
        Target_dialogue_name = name;
        dialogueLines = script;
    }
}

public class TextImport : MonoBehaviour {

    //A collection of scripts
    public ScriptCollector[] scripts;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < scripts.Length; i++)
        {
            if(TextManager.instance.PrintText(scripts[i].Target_dialogue_name) != null)
                scripts[i].dialogueLines = FindObjectOfType<TextManager>().PrintText(scripts[i].Target_dialogue_name);
        }
    }
}
