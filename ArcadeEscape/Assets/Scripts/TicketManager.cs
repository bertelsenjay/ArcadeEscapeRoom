using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class TicketManager : MonoBehaviour
{

    public static int tickets = 0;
    public int initialTickets = 50; 
    public TextMeshProUGUI ticketText; 

    // Start is called before the first frame update
    void Start()
    {
        tickets = initialTickets;
    }

    // Update is called once per frame
    void Update()
    {
        ticketText.text = "Tickets: " + tickets;
    }

    public void EarnTickets(int ticketCount)
    {
        tickets += ticketCount; 
    }


}
