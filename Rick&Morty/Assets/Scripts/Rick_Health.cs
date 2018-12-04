using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rick_Health : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -7)
        {
            Die();
        }
        
    }
    void Die()
    {
        SceneManager.LoadScene("DeadMenu"); //start a new game if the player has died
    }

   
}
