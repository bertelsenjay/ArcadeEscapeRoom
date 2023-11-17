using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float gameTimer = 30f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;
        if (gameTimer > 0f)
        {
            timerText.text = "Time: " + Mathf.Floor(gameTimer);
        }
        else
        {
            timerText.text = "Score: ";
        }
    }
}
