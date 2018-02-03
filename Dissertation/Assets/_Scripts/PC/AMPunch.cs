using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMPunch : MonoBehaviour {

    public GameObject AM_Punch;
    float coolDown = 0;
    public bool BL_SlowDown;
    bool punch = false;
    bool allowable = true;
	
	// Update is called once per frame
	void Update () {

        if(allowable)
            punch = Input.GetKey(GameManager.instance.KC_Punch);

        if (allowable && punch)
        {
            StartCoroutine(Punch());
        }
    }

    IEnumerator Punch()
    {
        PC_Controller.anim_Player.SetBool("BL_Punch", true);
        allowable = false;
        BL_SlowDown = true;
        yield return new WaitForSeconds(1.0f);
        FirePunch();
        yield return new WaitForSeconds(1.0f);
        BL_SlowDown = false;
        PC_Controller.anim_Player.SetBool("BL_Punch", false);
        yield return new WaitForSeconds(5.0f);
        allowable = true;
    }

    void FirePunch()
    {
        var _fist = (GameObject)Instantiate(AM_Punch,
            transform.position + transform.TransformDirection(new Vector3(0, 1, 0)), 
            transform.rotation);
    }
}
