using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ShootingManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI timerText;
    public float gameTimer = 30f;
    public float easyInitialGameTimer = 40f;
    public float normalInitialGameTimer = 30f;
    public float hardInitialGameTimer = 25f; 
    public TextMeshProUGUI scoreText;
    private bool once = false;
    TicketManager ticketManager;
    public static bool hasBeatHighScore = false;
    public float easyHighScore = 30;
    public float normalHighScore = 35;
    public float hardHighScore = 40;
    public float currentHighScore = 0f;
    public TextMeshProUGUI highScoreText; 
    LockManager lockManager;
    public AudioClip finishSound;
    AudioSource audioSource;
    private bool audioOnce = false; 
    // Start is called before the first frame update
    void Start()
    {
        ticketManager = FindObjectOfType<TicketManager>();
        lockManager = FindObjectOfType<LockManager>();
        audioSource = GetComponent<AudioSource>();
        score = 0;
        if (DifficultySelect.isEasy)
        {
            currentHighScore = easyHighScore;
        }
        if (DifficultySelect.isNormal)
        {
            currentHighScore = normalHighScore;
        }
        if (DifficultySelect.isHard) 
        {
            currentHighScore = hardHighScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = "High Score: " + currentHighScore;
        if (score >= currentHighScore)
        {
            currentHighScore = score;
        }
        if (gameTimer > 0f)
        {
            gameTimer -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Floor(gameTimer);

        }
        else
        {
            timerText.text = "Press button to start";
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
                if (DifficultySelect.isEasy && score >  easyHighScore && !hasBeatHighScore)
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
                    ObjectiveManager.hasPlayerShooter = true;
                }
            }
        }
        scoreText.text = "Score: " + score; 
    }

    public void AddScore(int amount)
    {
        if (gameTimer > 0f)
        {
            score += amount;

        }
    }

    public void StartGame()
    {
        if (gameTimer <= 0f)
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
