using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;
    public float lowestDelay = 5f;
    public float highestDelay = 10f; 
    float randomDelay = 5f;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        randomDelay = Random.Range(lowestDelay, highestDelay);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
            StartCoroutine(ResetCollision());
        }
    }

    private IEnumerator ResetCollision()
    {
        yield return new WaitForSeconds(randomDelay);
        randomDelay = Random.Range(lowestDelay, highestDelay);
        meshRenderer.enabled = true;
        boxCollider.enabled = true; 
    }
}