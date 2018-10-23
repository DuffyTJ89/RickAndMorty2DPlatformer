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
    void Update() {

        PlayerMove();
        PlayerRaycast();
    }

    void PlayerMove()
    {
        //controls

        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true)
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

    void Jump()
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

    void OnCollisionEnter2D(Collision2D col)
    {
        
    }

    void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        if (hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag == "enemy")
        {
            //Debug.Log("Touched enemy");
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
        }

        if (hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag != "enemy")
        {
            //Debug.Log("Touched enemy");
            isGrounded = true;
        }
    }
}
