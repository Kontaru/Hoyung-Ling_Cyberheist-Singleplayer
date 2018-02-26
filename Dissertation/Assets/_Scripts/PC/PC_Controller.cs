using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PC_Controller : Entity
{

    //---------------------------------------------------------------------------
    //----- The brain of the PC: handles all the other functions in its system
    //---------------------------------------------------------------------------

    public static GameObject playerLook;
    public GameObject Model;
    public static Animator anim_Player;


    //------- Rigidbody -----------
    //Rigidbody RB_PC;
    //Vector3 direction;

    //------ Character Controller ----------
    CharacterController CC_Player;
    AMPunch amPunch;

    [Header("Movement")]
    float FL_moveSpeed = 10f;
    float FL_defaultSpeed;

    // Use this for initialization
    void Start()
    {
        //Telling the GameManager who the players are
        for (int i = 0; i < GameManager.instance.GO_Player.Length; i++)
        {
            //For the current index, if it's empty
            if (GameManager.instance.GO_Player[i] == null)
            {
                //Make the gameobject this, and quit the cycle of sadness
                GameManager.instance.GO_Player[i] = gameObject;
                break;
            }
        }

        CameraFollow.PlayerRef = gameObject;


        //Some components
        amPunch = GetComponent<AMPunch>();
        //RB_PC = GetComponent<Rigidbody>();
        CC_Player = GetComponent<CharacterController>();

        anim_Player = Model.GetComponent<Animator>();

        FL_defaultSpeed = FL_moveSpeed;

        //When the player exists in the scene, the player will stop the theme and start playing the game BGM.
        AudioManager.instance.Stop("Theme");
        AudioManager.instance.Play("Game BGM");
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;

        if (amPunch.BL_SlowDown)
            FL_moveSpeed = 2.0f;
        else
            FL_moveSpeed = FL_defaultSpeed;

        if (anim_Player != null)
            anim_Player.SetBool("BL_Move", false);

        MovePlayer();
        PlayerLook();
    }

    //private void FixedUpdate()
    //{
    //    RB_PC.MovePosition(transform.position + direction * Time.fixedDeltaTime);
    //}

    void PlayerLook()
    {
        if (Vector3.Distance(transform.position, playerLook.transform.position) > 0.1f)
        {
            Vector3 lookPos = playerLook.transform.position - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5f * Time.deltaTime);
        }
    }

    #region Movement Controls

    //-------------------------------------------------------
    //Movement based on WASD
    //-------------------------------------------------------

    //Rigidbody
    //void PlayerMove()
    //{
    //    Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    //    direction = moveInput.normalized * FL_moveSpeed;
    //}

    //Character Controller
    void MovePlayer()
    {
        Vector3 V_MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));                 //Get Axis Horizontal and Vertical represent typical WASD inputs, and outputs either 1 or -1 depending on what was pressed.

        if (V_MoveDirection != new Vector3(0, 0, 0) && anim_Player != null)
            anim_Player.SetBool("BL_Move", true);

        //Isometric Movement
        V_MoveDirection = FL_moveSpeed * V_MoveDirection;

        //Third Person Movement
        //V_MoveDirection = FL_moveSpeed * transform.TransformDirection(V_MoveDirection);    //Convert this to a local vector (Otherwise is local, TransformDirection converts this). Adjust by speed.

        CC_Player.Move(V_MoveDirection * Time.deltaTime);                              //Move! (Function as a part of Unity)
    }

    #endregion
}
