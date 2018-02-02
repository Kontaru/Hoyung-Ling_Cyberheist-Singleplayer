using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

public class AMPunch : NetworkBehaviour {

    public GameObject AM_Punch;
    float coolDown = 0;
    public bool BL_SlowDown;
    bool punch = false;
    bool allowable = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }

        if(allowable)
            punch = CrossPlatformInputManager.GetButton("Punch");

        if (allowable && punch)
        {
            Cmd_FirePunch();
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        allowable = false;
        BL_SlowDown = true;
        yield return new WaitForSeconds(1.0f);
        BL_SlowDown = false;
        yield return new WaitForSeconds(6.0f);
        allowable = true;
    }

    [Command]
    void Cmd_FirePunch()
    {
        var _fist = (GameObject)Instantiate(AM_Punch,
            transform.position + transform.TransformDirection(new Vector3(0, 1, 0)), 
            transform.rotation);

        NetworkServer.Spawn(_fist);
    }
}
