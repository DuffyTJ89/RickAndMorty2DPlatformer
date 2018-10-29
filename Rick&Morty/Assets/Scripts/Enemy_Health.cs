using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour {

    void Update()
    {
        if (gameObject.transform.position.y < -10)
        {
            Destroy(gameObject); //destroy the enemy when they fall below a certain point
        }

    }
}
