using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI priceText; 
    public int ticketsNeeded = 10;
    public bool unlock = false;
    public bool crowBar = false;
    public bool unlockSection2 = false;
   /* public int unlockPrice = 100;
    public int crowBarPrice = 100;
    public int unlockSection2Price = 50;*/
    private bool hasUnlockBeenBought = false;
    private bool hasCrowBarBeenBought = false;
    private bool hasSection2BeenBought = false; 
    LockManager lockManager;
    public GameObject section2Divider;
    public GameObject crowBarObject;
    public Transform crowBarSpawn; 
    private void Awake()
    {
        lockManager = FindObjectOfType<LockManager>();
    }

    private void Update()
    {
        
        if (unlock && !hasUnlockBeenBought)
        {
            priceText.text = "Door Lock: " + ticketsNeeded;
        }
        else if (unlock && hasUnlockBeenBought)
        {
            priceText.text = "Sold Out";
        }
        if (crowBar && !hasCrowBarBeenBought)
        {
            priceText.text = "CrowBar: " + ticketsNeeded;
        }
        else if (crowBar && hasCrowBarBeenBought)
        {
            priceText.text = "Sold Out";
        }
        if (unlockSection2 && !hasSection2BeenBought)
        {
            priceText.text = "Unlock Section 2: " + ticketsNeeded; 
        }
        else if (unlockSection2 && hasSection2BeenBought)
        {
            priceText.text = "Sold Out";
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerHand")
        {
            if (unlock && !hasUnlockBeenBought)
            {
                if (TicketManager.tickets >= ticketsNeeded)
                {
                    TicketManager.tickets -= ticketsNeeded;
                    lockManager.UnlockLock();
                    hasUnlockBeenBought = true;
                }
            }
            if (crowBar && !hasCrowBarBeenBought)
            {
                if (TicketManager.tickets >= ticketsNeeded)
                {
                    TicketManager.tickets -= ticketsNeeded;
                    hasCrowBarBeenBought = true;
                    //Spawn Crowbar

                }
            }
            if (unlockSection2 && !hasSection2BeenBought) 
            {
                if (TicketManager.tickets >= ticketsNeeded)
                {
                    TicketManager.tickets -= ticketsNeeded;
                    hasSection2BeenBought = true;
                    Destroy(section2Divider);
                    //Unlock Section 2
                }
            }
        }
    }*/

    public void PurchaseUnlock()
    {
        if (!hasUnlockBeenBought)
        {
            if (TicketManager.tickets >= ticketsNeeded)
            {
                TicketManager.tickets -= ticketsNeeded;
                lockManager.UnlockLock(); 
                hasUnlockBeenBought = true;
            }
        }

    }

    public void PurchaseCrowBar()
    {
        Instantiate(crowBarObject, crowBarSpawn.position, Quaternion.identity);
        if (!hasCrowBarBeenBought)
        {
            if (TicketManager.tickets >= ticketsNeeded)
            {
                TicketManager.tickets -= ticketsNeeded;
                hasCrowBarBeenBought = true;
                //Spawn Crowbar
                Instantiate(crowBarObject, crowBarSpawn.position, Quaternion.identity);
            }
        }

    }
    public void PurchaseSectionTwo()
    {
        if (!hasSection2BeenBought)
        {
            if (TicketManager.tickets >= ticketsNeeded)
            {
                TicketManager.tickets -= ticketsNeeded;
                hasSection2BeenBought = true;
                Destroy(section2Divider);
                ObjectiveManager.hasPurchasedSectionTwo = true;
            }
        }
    }
}
