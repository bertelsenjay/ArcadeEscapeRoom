using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JoystickControl : MonoBehaviour
{
    public Transform topOfJoystick;

    [SerializeField] private float forwardBackwardTilt;
    [SerializeField] private float sideToSideTilt;

    void Update()
    {
        forwardBackwardTilt = topOfJoystick.rotation.eulerAngles.x; 
        if (forwardBackwardTilt < 355 && forwardBackwardTilt > 290)
        {
            forwardBackwardTilt = Math.Abs(forwardBackwardTilt - 360);
            Debug.Log("Backward");
        }
        else if (forwardBackwardTilt > 5 &&  forwardBackwardTilt < 74)
        {
            Debug.Log("Forward");
        }

        sideToSideTilt = topOfJoystick.rotation.eulerAngles.z;
        if (sideToSideTilt < 355 &&  sideToSideTilt > 290)
        {
            sideToSideTilt = Math.Abs(sideToSideTilt - 360);
            Debug.Log("Right");
        }
        else if (sideToSideTilt > 5 && sideToSideTilt < 74)
        {
            Debug.Log("Left");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            transform.LookAt(other.transform.position, transform.up);
        }
    }
}
