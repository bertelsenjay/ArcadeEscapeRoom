using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    BallGameManager gameManager;
    private Vector3 startingPosition; 
    Rigidbody rb;
    private void Start()
    {
        gameManager = FindObjectOfType<BallGameManager>();
        startingPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BallScoring" && !BallGameManager.tenSecondsLeft)
        {
            gameManager.AddScore(4);
            //Invoke("SetToStartingPosition", 1);
            SetToStartingPosition();
        }
        else if (other.gameObject.tag == "BallScoring" &&  BallGameManager.tenSecondsLeft)
        {
            gameManager.AddScore(6);
            //Invoke("SetToStartingPosition", 1);
            SetToStartingPosition();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BallDestroy")
        {
            SetToStartingPosition();
        }
    }

    public void SetToStartingPosition()
    {
        transform.position = startingPosition;
        rb.velocity = Vector3.zero; 
    }
}
