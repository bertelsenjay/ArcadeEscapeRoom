using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static bool openDoor = false;

    private void Update()
    {
        if (openDoor)
        {
            openDoor = false;
            Destroy(gameObject);
        }
    }
}
