using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    //Camera look references
    public static GameObject PlayerRef;
    public static GameObject otherLook;          //Reference to anything else we want to look at

    //Camera follow speeds - camera lerps between values for a more cinematic look!
    public float smoothSpeed = 2f;
    public float playerfollowSmoothSpeed = 10f;
    float speed = 1;

    private void Start()
    {
        speed = smoothSpeed;
    }

    // Use this for initialization
    void Update () {

        //If we have an otherLook target, then look at that instead
        if (otherLook != null)
        {
            Follow(otherLook);
            if (Vector3.Distance(transform.position, otherLook.transform.position) < 1.0f)
                StartCoroutine(StopLooking(otherLook));
        }
        //Otherwise if the player ref is stated, do the follow
        else if (PlayerRef != null)
            Follow(PlayerRef);


    }

    //Parents an object to another thing
    void Follow(GameObject parentGo)
    {
        if (Vector3.Distance(transform.position, parentGo.transform.position) < 10.0f)
            speed = Mathf.Lerp(speed, playerfollowSmoothSpeed, Time.deltaTime);
        else
            speed = Mathf.Lerp(speed, smoothSpeed, Time.deltaTime);

        //Sets the position of this gameobject to the "parent"
        transform.position = Vector3.Lerp(transform.position, parentGo.transform.position, speed * Time.deltaTime);
    }

    //After a few seconds, make the thing we're looking at = null, which should stop the camera from ever tracking this item.
    IEnumerator StopLooking(GameObject parentGO)
    {
        yield return new WaitForSeconds(3.0f);
        parentGO = null;
    }
}
