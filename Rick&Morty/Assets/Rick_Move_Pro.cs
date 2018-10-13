using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rick_Move_Pro : MonoBehaviour {

    public int rickSpeed = 10;
    public bool facingRight = true;
    public int rickJumpPower = 1250;
    private float moveX;

	// Update is called once per frame
	void Update () {

        PlayerMove();  
		
	}

    void PlayerMove()
    {
        //controls

        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown ("Jump"))
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

    }

    void FlipPlayer()
    {
        facingRight = !facingRight; //we dont want to be facing right anymore
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1; //flip the player by making the value negitive 
        transform.localScale = localScale;
        
    }
}
