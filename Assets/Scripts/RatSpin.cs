using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpin : MonoBehaviour
{
    public Joystick joystick;
    public float rotateHorizontal,
                 rotateVertical,
                 maxSpeed = .5f,
                 spinSpeed;

    public Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rotateHorizontal = Joystick.Horizontal * -1f;
        rotateVertical = Joystick.Vertical * 1f;

        transform.Rotate(rotateVertical * maxSpeed, 0, rotateHorizontal*maxSpeed);

        spinSpeed = rb.angularVelocity.magnitude;



        /*if(rotateVertical > 0 && rotateVertical < 20 || rotateVertical < 0 && rotateVertical > -20)
        {
            ratSpeed = "Slow";
            Debug.Log(ratSpeed);
        }

        if (rotateVertical > 0 && rotateVertical < 50 || rotateVertical < 0 && rotateVertical > -50)
        {
            ratSpeed = "Medium";
            Debug.Log(ratSpeed);
        }*/

    }
}
