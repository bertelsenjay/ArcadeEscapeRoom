using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowBarDoor : MonoBehaviour
{

    public GameObject key;
    public Transform keySpawn; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CrowBar")
        {
            Instantiate(key, keySpawn.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
