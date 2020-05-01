using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (Rigidbody2D))]
public class ShipMovAcc : MonoBehaviour
{
    public int mainSail = 0;
    private bool vCooldown;
    public float forwardVelocity, forwardAcceleration, angularVel;
    public float  maxAngVel = 20;
        float InputX;
        float InputY;

    // Start is called before the first frame update
    void Awake()
    {
        mainSail = 0;
        vCooldown = false;
        angularVel = 0;
        maxAngVel = 20;
    }

    // Update is called once per frame
    void Update(){
        //Get inputs
        InputX = -1 *(Input.GetAxisRaw("Horizontal"));
        InputY = Input.GetAxisRaw("Vertical");
        mainSailDeploy(InputY);
        currentAngularVelocity(InputX);
    }
    void FixedUpdate()
    {
        
        //Ship Angle Calculations
        GetComponent<Rigidbody2D>().angularVelocity = angularVel;
        float shipAngle = transform.localRotation.eulerAngles.z;
        //Forwad Velocity.
        calculateForwardVelocity();
        GetComponent<Rigidbody2D>().velocity= seperateVelocity(shipAngle, forwardVelocity);
    }
    void currentAngularVelocity(float i){
        angularVel = angularVel + i/10;
        if (Mathf.Abs(angularVel) > maxAngVel){
            if(angularVel > 0){
                angularVel = maxAngVel;
            }else{
                angularVel = maxAngVel * -1;
            }
        }
    }

    void mainSailDeploy(float i){
        if (Input.GetButtonDown("Jump")){
            mainSail++;
            if(mainSail == 3){mainSail = 0;}
        }
        setForwardAcceleration();
    }
    void setForwardAcceleration(){
        switch(mainSail){
            case 0:
            forwardAcceleration = -0.1f;
            maxAngVel = 10;
            break;
            case 1:
            forwardAcceleration = 0.1f;
            maxAngVel = 35;
            break;
            case 2:
            forwardAcceleration = 0.2f;
            maxAngVel = 25;
            break;
        }
    }
    void calculateForwardVelocity(){
        switch(mainSail){
            case 0:
            if (forwardVelocity>0){forwardVelocity += forwardAcceleration;}
            break;
            case 1:
            if (forwardVelocity<6){forwardVelocity += forwardAcceleration;}
            break;
            case 2:
            if (forwardVelocity<12){forwardVelocity += forwardAcceleration;}
            break;
        }
    }

    Vector2 seperateVelocity(float angle, float radius){
        float vx = radius * Mathf.Sin(ConvertToRadians(angle)) *-1;
        float vy = radius * Mathf.Cos(ConvertToRadians(angle));
        return new Vector2(vx,vy);
    }
    public float ConvertToRadians(float angle)
    {
        return (Mathf.PI / 180) * angle;
    }
}
