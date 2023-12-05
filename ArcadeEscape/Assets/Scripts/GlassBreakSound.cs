using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBreakSound : MonoBehaviour
{

    public AudioClip breakingGlass;
    public float breakingGlassVolume = 1f;
    AudioSource audioSource;
    private bool once = false; 

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!once)
        {
            once = true;
            audioSource.PlayOneShot(breakingGlass, breakingGlassVolume);
        }
    }
}
