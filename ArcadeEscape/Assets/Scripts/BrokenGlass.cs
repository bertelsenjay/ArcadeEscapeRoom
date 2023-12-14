using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenGlass : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip breakSound;
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(breakSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
