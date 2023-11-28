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
        if (other.gameObject.tag == "BallScoring" && !BallGameManager.tenSecondsLeft && BallGameButton.isPlaying)
        {
            gameManager.AddScore(2);
        }
        else if (other.gameObject.tag == "BallScoring" &&  BallGameManager.tenSecondsLeft && BallGameButton.isPlaying)
        {
            gameManager.AddScore(3);
        }
    }
}
