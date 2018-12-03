using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour {

    private float timeLeft = 10;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;

    void Start()
    {
        DataManagement.dataManagement.loadData();
    }


    // Update is called once per frame
    void Update () {
        
        timeLeft -= Time.deltaTime; // runs time down one second at a time
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left : " + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score : " + playerScore);

        if (timeLeft< 0.1f)
        {
            SceneManager.LoadScene("DeadMenu"); //player has died because they ran out of time
        }
	}

    void OnTriggerEnter2D (Collider2D trig)
    {
        //Debug.Log("End level");
        if (trig.gameObject.name =="EndLevel")
        {
            CountScore();
            Debug.Log("Level End");
            if (trig.gameObject.tag == "EndGame")
            {
                SceneManager.LoadScene("EndMenu");
            }
            else
            {
                SceneManager.LoadScene(2);
            }
                
        }
        if (trig.gameObject.name == "MegaSeed")
        {
            playerScore += 10;
            Destroy(trig.gameObject);
        }
    }

    void CountScore()
    {
        playerScore = playerScore + (int)(timeLeft * 10);
        DataManagement.dataManagement.highScore = playerScore;
   
        DataManagement.dataManagement.saveData();
        Debug.Log(playerScore);
    }

}

