using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookFollow : MonoBehaviour {

    //Variables
    Vector3 MousePos;

    // Use this for initialization
    void Start()
    {
        PC_Controller.playerLook = gameObject;
    }

    void Update()
    {
        MousePosition();                                                    //Get mouse position
        transform.position = MousePos;                                  //Set the box's position to our projected position
    }

    private void MousePosition()
    {
        int layerMask = 1 << 8;                                             //Layer mask allows other layers to be ignored

        RaycastHit hit;                                                     //Hit data

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);         //Raycast from screen to mouse

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))       //If there is a hit with the ray...
        {
            MousePos = hit.point;                                           //Store settings for the hit point on the plane
            MousePos.y += 0.1f;                                            //Set the y value appropriately so the player hits straight
        }
    }
}
