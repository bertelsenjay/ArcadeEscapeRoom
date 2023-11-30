using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public int health = 2;
    public GameObject key;
    public Transform keySpawn; 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Hammer")
        {
            health--; 
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(key, keySpawn.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
