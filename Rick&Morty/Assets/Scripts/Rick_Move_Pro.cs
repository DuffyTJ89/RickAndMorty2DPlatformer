using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rick_Move_Pro : MonoBehaviour {

    public int rickSpeed = 10;
    public bool facingRight = false;
    public int rickJumpPower = 1250;
    private float moveX;
    public bool isGrounded;

	// Update is called once per frame
	void Update () {

        PlayerMove();  
		
	}

    void PlayerMove()
    {
        //controls

        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown ("Jump") && isGrounded == true)
        {
            Jump();
        }
            
        //animations

        //player direction

        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }

        //physics 

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * rickSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    void Jump ()
    {
        //jumping code
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * rickJumpPower);
        isGrounded = false;

    }

    void FlipPlayer()
    {
        facingRight = !facingRight; //we dont want to be facing right anymore
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1; //flip the player by making the value negitive 
        transform.localScale = localScale;
        
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        Debug.Log("Player has collided with" + col.collider.name);
        if(col.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }
}
