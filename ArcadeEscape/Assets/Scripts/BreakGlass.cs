using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGlass : MonoBehaviour
{
    public GameObject brokenPane;
    public GameObject key;
    public Transform keyPosition; 
    //public float velocityMagnitude = 5f;
    //
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hammer" || collision.gameObject.tag == "Bullet")
        {
            Instantiate(key, keyPosition.position, Quaternion.identity);
            brokenPane.SetActive(true);
            Destroy(gameObject); 
        }
    }
}
