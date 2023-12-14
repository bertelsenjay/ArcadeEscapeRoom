using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class KeyCanvas : MonoBehaviour
{

    LockManager lockManager;
    public TextMeshProUGUI displayText;
    // Start is called before the first frame update
    void Start()
    {
        lockManager = FindObjectOfType<LockManager>();
        
    }

    private void Update()
    {
        displayText.text = "Key Found,\n" + lockManager.GetLocksLeft() + " Left";
    }
}
