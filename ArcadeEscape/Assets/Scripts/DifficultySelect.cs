using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelect : MonoBehaviour
{
    public static bool isEasy = false;
    public static bool isNormal = true;
    public static bool isHard = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEasy()
    {
        isEasy = true;
        isNormal = false;
        isHard = false;
        ResetStaticVariables();
        SceneManager.LoadScene("ArcadeTemplate");
    }

    public void SetNormal()
    {
        isEasy = false;
        isNormal = true;
        isHard = false;
        ResetStaticVariables();
        SceneManager.LoadScene("ArcadeTemplate");
    }

    public void SetHard()
    {
        isEasy = false;
        isNormal = false;
        isHard = true;
        ResetStaticVariables();
        SceneManager.LoadScene("ArcadeTemplate");
    }

    public void ResetStaticVariables()
    {
        BallGameButton.isPlaying = false;
        BallGameManager.tenSecondsLeft = false; 
        BallGameManager.hasBeatHighScore = false;
        ShootingManager.hasBeatHighScore = false;
        GameController.score = 0;
        GameController.hasBeatHighScore = false;
        Door.openDoor = false;
        ObjectiveManager.hasPlayedWhackAMole = false;
        ObjectiveManager.hasPurchasedSectionTwo = false;
        ObjectiveManager.hasPlayedBall = false;
        ObjectiveManager.hasPlayerShooter = false;
        TicketManager.tickets = 0;
    }
}
