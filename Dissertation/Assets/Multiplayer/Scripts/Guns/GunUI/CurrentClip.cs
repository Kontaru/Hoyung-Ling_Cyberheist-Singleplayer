using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentClip : MonoBehaviour {

    TextMeshProUGUI myText;

    void Start()
    {
        myText = GetComponent<TextMeshProUGUI>();
        ActiveGun.currentClipText = myText;
    }
}
