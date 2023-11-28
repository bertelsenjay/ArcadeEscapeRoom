using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGameButton : MonoBehaviour
{

    ShootingManager shootingManager; 
    // Start is called before the first frame update
    void Start()
    {
        shootingManager = FindObjectOfType<ShootingManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            shootingManager.StartGame();
        }
    }
}
