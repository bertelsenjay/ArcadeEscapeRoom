using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallGameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI timerText;
    public float gameTimer = 30f;
    public float initialGameTimer = 30f;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        if (gameTimer > 0f)
        {
            gameTimer -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Floor(gameTimer);
        }
        else
        {
            timerText.text = "Press button to start";
        }

        scoreText.text = "Score: " + score;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
