using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    BallGameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<BallGameManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BallScoring")
        {
            gameManager.AddScore(2);
        }
    }
}
