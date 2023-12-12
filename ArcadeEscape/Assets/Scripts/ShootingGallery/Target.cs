using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    MeshRenderer meshRenderer;
    CapsuleCollider capsuleCollider;
    public float lowestDelay = 5f;
    public float highestDelay = 10f; 
    float randomDelay = 5f;
    TicketManager ticketManager;
    ShootingManager shootingManager;
    AudioSource audioSource;
    public AudioClip getHitSound;
    public float getHitVolume = 1f; 
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        randomDelay = Random.Range(lowestDelay, highestDelay);
        ticketManager = FindObjectOfType<TicketManager>();
        shootingManager = FindObjectOfType<ShootingManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            meshRenderer.enabled = false;
            capsuleCollider.enabled = false;
            shootingManager.AddScore(1);
            audioSource.PlayOneShot(getHitSound, getHitVolume);
            StartCoroutine(ResetCollision());
        }
    }

    private IEnumerator ResetCollision()
    {
        yield return new WaitForSeconds(randomDelay);
        if (DifficultySelect.isEasy)
        {
            randomDelay = Random.Range(lowestDelay * 1.2f, highestDelay * 1.2f);
            meshRenderer.enabled = true;
            capsuleCollider.enabled = true;
        }
        if (DifficultySelect.isNormal)
        {
            randomDelay = Random.Range(lowestDelay, highestDelay);
            meshRenderer.enabled = true;
            capsuleCollider.enabled = true;
        }
        if (DifficultySelect.isHard)
        {
            randomDelay = Random.Range(lowestDelay * 0.75f, highestDelay * 0.75f);
            meshRenderer.enabled = true;
            capsuleCollider.enabled = true;
        }
    }
}
