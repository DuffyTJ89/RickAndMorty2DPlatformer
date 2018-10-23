﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour {

    private float timeLeft = 125;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;

    // Update is called once per frame
    void Update () {
        timeLeft -= Time.deltaTime; // runs time down one second at a time
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left : " + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score : " + playerScore);

        if (timeLeft< 0.1f)
        {
            SceneManager.LoadScene("FirstScene"); //player has died because they ran out of time
        }
	}

    void OnTriggerEnter2D (Collider2D trig)
    {
        //Debug.Log("End level");

        CountScore();
    }

    void CountScore()
    {
        playerScore = playerScore + (int)(timeLeft * 10);
        Debug.Log(playerScore);
    }

}

