using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (Rigidbody2D))]
public class PlayerMov : MonoBehaviour
{

    public float playerSpeed = 2f;
    public Rigidbody2D ShipRB2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //account for ship velocity
        GetComponent<Rigidbody2D>().velocity=(inputVector * playerSpeed) + ShipRB2D.velocity;
        
    }
}
