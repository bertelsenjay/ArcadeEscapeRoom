using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float gameTimer = 30f;
    public float initialTimer = 0f; 
    public GameObject moleContainer;
    private Mole[] moles;
    public float showMoleTimer = 1.5f;
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    //public static bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        moles = moleContainer.GetComponentsInChildren<Mole>();
        Debug.Log(moles.Length);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameTimer > 0f)
        {
            gameTimer -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Floor(gameTimer);
            showMoleTimer -= Time.deltaTime;
            if (showMoleTimer < 0f)
            {
                moles[Random.Range(0, moles.Length)].ShowMole();

                showMoleTimer = 1.5f;
            }
        }
        else
        {
            timerText.text = "Hit button with hammer to start ";

        }

        scoreText.text = "Score: " + score; 
    }

    public void StartGame()
    {
        gameTimer = initialTimer;
        score = 0;
    }
}
