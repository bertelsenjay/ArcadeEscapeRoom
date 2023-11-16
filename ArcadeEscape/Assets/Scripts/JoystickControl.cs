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
        }

    }
}
