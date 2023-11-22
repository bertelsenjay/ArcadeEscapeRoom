using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhackAMoleButton : MonoBehaviour
{
    GameController gameController;
    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {
            gameController.StartGame();
        }
    }
}
