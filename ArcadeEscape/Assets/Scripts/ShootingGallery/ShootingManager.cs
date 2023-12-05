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
    // Start is called before the first frame update
    void Start()
    {
        ticketManager = FindObjectOfType<TicketManager>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
