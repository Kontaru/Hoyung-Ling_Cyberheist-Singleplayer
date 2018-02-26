using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingReference : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.instance.loadingScreen = gameObject;
        GameManager.instance.slider = transform.GetChild(0).GetComponent<Slider>();
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
