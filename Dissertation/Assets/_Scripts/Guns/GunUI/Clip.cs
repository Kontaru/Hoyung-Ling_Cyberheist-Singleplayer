using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clip : MonoBehaviour {

    TextMeshProUGUI myText;

    void Start()
    {
        myText = GetComponent<TextMeshProUGUI>();
        ActiveGun.clipText = myText;
    }
}
