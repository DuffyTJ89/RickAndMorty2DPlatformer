using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class morty_Move : MonoBehaviour {

    public int mortySpeed = 2;
    public int xMoveDirection = 1;

	
	// Update is called once per frame
	void Update () {

        RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (xMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (xMoveDirection, 0) * mortySpeed;

        if (hit.distance < 0.9f)
        {
            FlipMorty();

            if (hit.collider.tag == "Player")
            {

                Destroy(hit.collider.gameObject);
                //gameObject = null;
                SceneManager.LoadScene("DeadMenu"); //player dead, return to menu

            }
        }

	}

    void FlipMorty()
    {
        if (xMoveDirection > 0)
        {
            xMoveDirection = -1;
        }
        else
        {
            xMoveDirection = 1;
        }
    }
}
