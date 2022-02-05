using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
       public Rigidbody2D playerRb;
    private SpriteRenderer playerSprite;

    private float moveSpeed;
    private float jumpForce;

    private float moveHorizontal;
    private float moveVertical;
    
    public  LayerMask layer;


    // Start is called before the first frame update
    void Start()
    {
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 2f;
        jumpForce = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void FixedUpdate()
    {
        Move();

        
    }

    //Checks to see if player is touching the ground via raycast
    public bool IsGrounded()
    {
        LayerMask layer = LayerMask.GetMask("Ground");

        //if player is touching the ground - can jump
        if (Physics2D.Raycast(transform.position, -Vector2.up, 1 , layer.value))
        {
            Debug.Log("Player Can Jump");
            return true;
        }

        //if not - Player unable to jump - No Double Jump
        else
        {
            Debug.Log("Player can't Jump");
            return false;
        }
    }

    public void Move()
    {
        //Moves Player Horizontally - I changed the values a bit
        //In the previous script the player slides around a bit. I lessened that feature but it should be addressed a different way
        //^^Espescially if we do not want the player to slide around^^
        if ((moveHorizontal > 0.2f) || (moveHorizontal < -0.2f))
        {
            playerRb.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }
    }

    public void Jump()
    {
        //If the IsGround() method returns true - Player can jump
        if (IsGrounded())
        {
            playerRb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

}
