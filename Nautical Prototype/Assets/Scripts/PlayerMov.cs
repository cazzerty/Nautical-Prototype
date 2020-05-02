using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (Rigidbody2D))]
public class PlayerMov : MonoBehaviour
{

    public float playerSpeed = 2f;
    //public Rigidbody2D ShipRB2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        //account for ship velocity
        if (Mathf.Abs(inputVector.x) == 1 && Mathf.Abs(inputVector.y) == 1){
            
        }
        GetComponent<Rigidbody2D>().velocity = (inputVector * playerSpeed);
        //GetComponent<Rigidbody2D>().velocity=(inputVector * playerSpeed) + ShipRB2D.velocity;
        
    }
}
