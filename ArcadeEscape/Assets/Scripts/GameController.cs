using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float gameTimer = 30f;

    public GameObject moleContainer;
    private Mole[] moles;
    public float showMoleTimer = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        moles = moleContainer.GetComponentsInChildren<Mole>();
        Debug.Log(moles.Length);
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;
        if (gameTimer > 0f)
        {
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
            timerText.text = "Score: ";
        }
    }
}
