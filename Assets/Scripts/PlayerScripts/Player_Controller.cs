using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    //This script's purpose is to control the player character and it's components
    //Movement, Attacking, Getting Attacked, Interacting with the world, ETC, 

    //Necessary Components to grab
    private Animator PlayerAnim;
    private Rigidbody2D RigBod;
    private CapsuleCollider2D CapColl;

    //Private Vars
    private bool IsHurt = false;

    //Editor Inspector Variables
    [SerializeField] float MoveSpeed, JumpForce;






    // Start is called before the first frame update
    void Start()
    {
        //Grabbing Components
        PlayerAnim = GetComponent<Animator>();
        RigBod = GetComponent<Rigidbody2D>();
        CapColl = GetComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Temperary future proofing 
        if (!IsHurt)
        {
            //Usual Player code here
            PlayerMovement();

        }
        
    }

    //Movement Function
    private void PlayerMovement()
    {
        //Grab Input and store Floats and Bools
        float HorizInput = Input.GetAxis("Horizontal");
        RigBod.velocity = new Vector2(HorizInput * MoveSpeed, RigBod.velocity.y);
        //Change Animation to Running Here
        //Flip Sprite based on Direction Here
    }









}
