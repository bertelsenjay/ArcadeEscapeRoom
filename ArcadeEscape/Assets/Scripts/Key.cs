using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Key : MonoBehaviour
{
    public TextMeshProUGUI popup;
    LockManager lockManager;

    private void Awake()
    {
        lockManager = FindObjectOfType<LockManager>();
        lockManager.UnlockLock();
        popup.text = "You found a key!\nThere are " + lockManager.GetLocksLeft() + " locks left. ";
        Destroy(gameObject, 5f);
    }
}
