using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunName : MonoBehaviour {

    TextMeshProUGUI myText;

    void Start()
    {
        myText = GetComponent<TextMeshProUGUI>();
        ActiveGun.nameText = myText;
    }
}
