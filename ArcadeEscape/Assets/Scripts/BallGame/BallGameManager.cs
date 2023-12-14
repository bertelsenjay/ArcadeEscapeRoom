using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallGameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI timerText;
    public float gameTimer = 30f;
    public float easyInitialGameTimer = 40f;
    public float normalInitialGameTimer = 30f;
    public float hardInitialGameTimer = 25f; 
    public TextMeshProUGUI scoreText;
    public static bool tenSecondsLeft = false;
    private bool once = false;
    TicketManager ticketManager;
    public static bool hasBeatHighScore = false;
    public float easyHighScore = 30;
    public float normalHighScore = 40;
    public float hardHighScore = 40; 
    LockManager lockManager;
    public AudioClip finishSound;
    private bool audioOnce = false; 
    AudioSource audioSource; 
    private void Start()
    {
        ticketManager = FindObjectOfType<TicketManager>();
        lockManager = FindObjectOfType<LockManager>();
        audioSource = GetComponent<AudioSource>();
        score = 0;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            StartGame();
        }
        if (gameTimer < 10f)
        {
            tenSecondsLeft = true;
        }
        if (gameTimer > 0f)
        {
            gameTimer -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Floor(gameTimer);
        }
        else
        {
            BallGameButton.isPlaying = false;
            timerText.text = "Press button to start";
            tenSecondsLeft = false;
            if (once == false)
            {
                once = true;
                ticketManager.EarnTickets(Mathf.RoundToInt(score / 2));
                if (!audioOnce)
                {
                    audioOnce = true;
                }
                else
                {
                    audioSource.PlayOneShot(finishSound);
                }
                
                if (DifficultySelect.isEasy && score > easyHighScore && !hasBeatHighScore)
                {
                    hasBeatHighScore = true;
                    lockManager.UnlockLock(); 
                }
                if (DifficultySelect.isNormal && score > normalHighScore && !hasBeatHighScore)
                {
                    hasBeatHighScore = true;
                    lockManager.UnlockLock();
                }
                if (DifficultySelect.isHard && score > hardHighScore && !hasBeatHighScore)
                {
                    hasBeatHighScore = true;
                    lockManager.UnlockLock();
                }
                if (score > 0)
                {
                    ObjectiveManager.hasPlayedBall = true;
                }
                
            }
        }

        scoreText.text = "Score: " + score;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void StartGame()
    {
        if (gameTimer <= 0)
        {
            if (DifficultySelect.isEasy)
            {
                once = false;
                gameTimer = easyInitialGameTimer;
                score = 0;
            }
            
            if (DifficultySelect.isNormal)
            {
                once = false;
                gameTimer = normalInitialGameTimer;
                score = 0;
            }

            if (DifficultySelect.isHard)
            {
                once = false;
                gameTimer = hardInitialGameTimer;
                score = 0; 
            }
        }
        
    }
}
