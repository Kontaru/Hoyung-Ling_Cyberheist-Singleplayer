using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoText : MonoBehaviour {

    TextMeshProUGUI myText;

	void Start()
    {
        myText = GetComponent<TextMeshProUGUI>();
        ActiveGun.ammoText = myText;
    }
}
