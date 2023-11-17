using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;
    public float delay = 5f; 
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
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
        yield return new WaitForSeconds(delay);
        meshRenderer.enabled = true;
        boxCollider.enabled = true; 
    }
}
