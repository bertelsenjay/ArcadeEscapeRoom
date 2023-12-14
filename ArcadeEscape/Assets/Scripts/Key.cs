using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Key : MonoBehaviour
{
    public TextMeshProUGUI popup;
    LockManager lockManager;
    private bool once = false; 
    private void Awake()
    {
        Destroy(gameObject, 5f);
        lockManager = FindObjectOfType<LockManager>();
        lockManager.UnlockLock();
        popup.text = "You found a key!\nThere are " + lockManager.GetLocksLeft() + " locks left. ";
        
    }
    private void Update()
    {
        if (!once)
        {
            once = true;
            
        }
    }
}
