using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookFollow : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PC_Controller.playerLook = gameObject;
	}
}
