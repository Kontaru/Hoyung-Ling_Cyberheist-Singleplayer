using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

public class PC_Controller : Entity
{

    //---------------------------------------------------------------------------
    //----- The brain of the PC: handles all the other functions in its system
    //---------------------------------------------------------------------------

    public static GameObject playerLook;

    Rigidbody RB_PC;
    Vector3 direction;

    ActiveGun activeGun;
    AMPunch amPunch;

    [Header("Movement")]
    float FL_moveSpeed = 10f;
    float FL_defaultSpeed;

    // Client Variables
    [SyncVar]
    private Vector3 V3_syncPos;
    [SyncVar]
    private float FL_syncYRot;
    private float FL_lerpRate = 10f;

    public override void OnStartLocalPlayer()
    {
        transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    // Use this for initialization
    void Start()
    {
        if (isServer)
        {
            //Telling the GameManager who the players are
            for (int i = 0; i < GameManager.instance.GO_Player.Length; i++)
            {
                //For the current index, if it's empty
                if (GameManager.instance.GO_Player[i] == null)
                {
                    //Make the gameobject this, and quit the cycle of sadness
                    GameManager.instance.GO_Player[i] = gameObject;
                    Debug.Log("Player added");
                    break;
                }
            }
        }

        //If the camera is local player
        if (isLocalPlayer)
        {
            //From the camera follow script, set the reference to this game object.
            CameraFollow.PlayerRef = gameObject;
        }else if (!isLocalPlayer)
        {
            return;
        }

        activeGun = GetComponent<ActiveGun>();
        amPunch = GetComponent<AMPunch>();
        RB_PC = GetComponent<Rigidbody>();
        FL_defaultSpeed = FL_moveSpeed;

        //When the player exists in the scene, the player will stop the theme and start playing the game BGM.
        AudioManager.instance.Stop("Theme");
        AudioManager.instance.Play("Game BGM");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (amPunch.BL_SlowDown)
            FL_moveSpeed = 2.0f;
        else
            FL_moveSpeed = FL_defaultSpeed;

        PlayerMove();
        PlayerLook();
    }

    private void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }


        RB_PC.MovePosition(transform.position + direction * Time.fixedDeltaTime);
    }

    void PlayerMove()
    {
        Vector3 moveInput = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0, CrossPlatformInputManager.GetAxis("Vertical"));
        direction = moveInput.normalized * FL_moveSpeed;
    }

    void PlayerLook()
    {
        playerLook.transform.position = transform.position;
        Vector3 lookInput = new Vector3(CrossPlatformInputManager.GetAxis("LookHorizontal"), 0, CrossPlatformInputManager.GetAxis("LookVertical"));
        if (lookInput != new Vector3(0, 0, 0))
        {
            playerLook.transform.GetChild(0).localPosition = lookInput.normalized;
            transform.LookAt(playerLook.transform.GetChild(0));
        }
    }
}
