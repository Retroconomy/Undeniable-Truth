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
    private bool InAir = false;
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
            PlayerJump();
        }
        
    }

    //Movement Function
    private void PlayerMovement()
    {
        //Grab Input and store Floats and Bools
        float HorizInput = Input.GetAxis("Horizontal");
        RigBod.velocity = new Vector2(HorizInput * MoveSpeed, RigBod.velocity.y);
        ChangeAnimToRun();
        FlipSprite();
        }
    //Running Animation Function
    private void FlipSprite()
    {
        bool IsRunning = Mathf.Abs(RigBod.velocity.x) >= Mathf.Epsilon;
        if (IsRunning)
        {
            transform.localScale = new Vector2(Mathf.Sign(RigBod.velocity.x), 1f);
        }
    }
    private void ChangeAnimToRun()
    {
        bool IsRunning = Mathf.Abs(RigBod.velocity.x) >= Mathf.Epsilon;
        PlayerAnim.SetBool("IsRunning", IsRunning);
    }

    //Jump Function
    private void PlayerJump()
    {
        //Grab Input and check if player is on the ground
        bool PressedJump = Input.GetButtonDown("Jump");
        bool IsGrounded = CapColl.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if(PressedJump && IsGrounded)
        {
            RigBod.velocity = new Vector2(RigBod.velocity.x, JumpForce);
            
        }
        ChangeAnimToJump();
    }
    private void ChangeAnimToJump()
    {
        bool IsVert = Mathf.Abs(RigBod.velocity.y) > 0.005;
        PlayerAnim.SetBool("Jumped", IsVert);
    }






}
