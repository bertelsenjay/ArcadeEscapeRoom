using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float gameTimer = 30f;
    public float easyInitialTimer = 40f;
    public float normalInitialTimer = 30f;
    public float hardInitialTimer = 25f; 
    public GameObject moleContainer;
    private Mole[] moles;
    public float showMoleTimer = 1.5f;
    public float easyMoleTimer = 1.5f; 
    public float normalMoleTimer = 1.25f;
    public float hardMoleTimer = 1f; 
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    TicketManager ticketManager;
    private bool once = false;
    public static bool hasBeatHighScore = false;
    public float easyHighScore = 60f;
    public float normalHighScore = 50f;
    public float hardHighScore = 60f; 
    LockManager lockManager;
    public AudioClip finishSound;
    AudioSource audioSource;
    private bool audioOnce = false; 
    //public Transform hammerSpawnPoint;
    //public GameObject hammer; 
    //public static bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        ticketManager = FindObjectOfType<TicketManager>();
        moles = moleContainer.GetComponentsInChildren<Mole>();
        lockManager = FindObjectOfType<LockManager>();
        audioSource = GetComponent<AudioSource>();
        Debug.Log(moles.Length);
        score = 0;
        if (DifficultySelect.isEasy)
        {
            showMoleTimer = easyMoleTimer;
        }
        if (DifficultySelect.isNormal)
        {
            showMoleTimer = normalMoleTimer;
        }
        if (DifficultySelect.isHard)
        {
            showMoleTimer = hardMoleTimer; 
        }

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

                if (DifficultySelect.isEasy)
                {
                    showMoleTimer = easyMoleTimer;
                }
                if (DifficultySelect.isNormal)
                {
                    showMoleTimer = normalMoleTimer;
                }
                if (DifficultySelect.isHard)
                {
                    showMoleTimer = hardMoleTimer;
                }
            }
        }
        else
        {
            timerText.text = "Hit mole with hammer to start ";
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
                if (DifficultySelect.isHard && score >  hardHighScore && !hasBeatHighScore)
                {
                    hasBeatHighScore = true;
                    lockManager.UnlockLock();   
                }
                //Destroy(hammer);
            }
        }

        scoreText.text = "Score: " + score; 
    }

    public void StartGame()
    {
        if (gameTimer <= 0f)
        {
            //Instantiate(hammer, hammerSpawnPoint.position, Quaternion.identity);
            if (DifficultySelect.isEasy)
            {
                once = false;
                gameTimer = easyInitialTimer;
                score = 0;
            }
            if (DifficultySelect.isNormal)
            {
                once = false;
                gameTimer = normalInitialTimer;
                score = 0;
            }
            if (DifficultySelect.isHard)
            {
                once = false;
                gameTimer = hardInitialTimer;
                score = 0;
            }
        }
        
    }
}
