using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rick_Move_Pro : MonoBehaviour {

    public int rickSpeed = 10;
    public bool facingRight = true;
    public int playerJumpPower = 1250;
    public float moveX;

	// Update is called once per frame
	void Update () {

        PlayerMove();  
		
	}

    void PlayerMove()
    {
        //controls

        moveX = Input.GetAxis("Horizontal");
        

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

    void jump ()
    {
        //jumping code


    }

    void FlipPlayer()
    {

    }
}
