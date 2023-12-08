using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ObjectiveManager : MonoBehaviour
{
    public string[] objectives;
    public int index = 0;
    public TextMeshProUGUI objectiveText;
    public static bool hasPlayedWhackAMole = false;
    public static bool hasPurchasedSectionTwo = false;
    public static bool hasPlayedBall = false;
    public static bool hasPlayerShooter = false; 
    private bool moleOnce = false;
    private bool ticketOnce = false;
    private bool sectionTwoOnce = false; 
    LockManager lockManager;

    private void Start()
    {
        lockManager = FindObjectOfType<LockManager>();
    }
    private void Update()
    {
        objectiveText.text = objectives[index];
        if (TicketManager.tickets > 0 && !moleOnce && index == 0)
        {
            moleOnce = true;
            IncrementIndex();
        }

        if (TicketManager.tickets >= 50 && !ticketOnce && index == 1)
        {
            ticketOnce = true;
            IncrementIndex(); 
        }

        if (hasPurchasedSectionTwo && !sectionTwoOnce && index == 2)
        {
            sectionTwoOnce = true;
            IncrementIndex();
        }

        if (hasPlayedBall && index == 3)
        {
            IncrementIndex();
        }

        if (hasPlayerShooter && index == 4)
        {
            IncrementIndex(); 
        }

        if (lockManager.GetLocksLeft() <= 0 && index == 5)
        {
            IncrementIndex(); 
        }
    }

    public void IncrementIndex()
    {
        if (index >= objectives.Length) { return; }
        index++;
        Debug.Log("Incremented");
    }
}
