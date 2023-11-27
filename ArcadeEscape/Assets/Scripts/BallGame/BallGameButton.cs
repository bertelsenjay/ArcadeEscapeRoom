using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGameButton : MonoBehaviour
{

    BallGameManager ballGameManager;
    public static bool isPlaying = false; 
    // Start is called before the first frame update
    void Start()
    {
        ballGameManager = FindObjectOfType<BallGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            ballGameManager.StartGame();
            isPlaying = true;
        }
    }
}
