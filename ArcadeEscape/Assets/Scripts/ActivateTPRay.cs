using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTPRay : MonoBehaviour
{
    public GameObject teleportation;

    public InputActionProperty activate;

    private void Update()
    {
        teleportation.SetActive(activate.action.ReadValue<float>() > 0.1);
    }
}
