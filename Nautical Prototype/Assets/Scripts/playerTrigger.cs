using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTrigger : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D dataFromCollision) {
        if (dataFromCollision.gameObject.name == "MainMast")
        {
            Debug.Log(dataFromCollision.gameObject.name);
        }
        
    }
}
