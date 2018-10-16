using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rick_Health : MonoBehaviour
{

    public int health;
    public bool hasDied;

    // Use this for initialization
    void Start()
    {
        hasDied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -7)
        {
            //Debug.Log("Player has died"); //check to see if the player triggers this below the postion
            hasDied = true;
        }
        if (hasDied == true)
        {
            StartCoroutine("Die"); //StartCoroutine function always returns immediately
        }
    }
        IEnumerator Die()
        {
            SceneManager.LoadScene("FirstScene"); //start a new game if the player has died
            yield return null;
        }

   
}
