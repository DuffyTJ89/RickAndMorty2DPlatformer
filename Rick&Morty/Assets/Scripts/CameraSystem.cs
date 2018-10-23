using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

    public GameObject player;
    //keep camera to a postion in a range
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // Use this for initialization
    void Start () {
        //look for object with the tag player
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void LateUpdate () { //lateupdate is used at the end of the update cycle

        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3 (x, y, gameObject.transform.position.z);
    }
}
