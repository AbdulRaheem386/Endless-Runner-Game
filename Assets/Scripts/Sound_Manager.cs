using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    public static Sound_Manager instance;

    public AudioSource audioSource;

    public AudioClip ClickSound;
    public AudioClip hitSound;
    public AudioClip jumpSound;
    public AudioClip sideSound;


    private void Awake()
    {
        instance = this;
    }

    public void PlayClick()
    {
        audioSource.PlayOneShot(ClickSound);
    }

    public void Playhit()
    {
        audioSource.PlayOneShot(hitSound);
    }

    public void Playjump()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void Playside()
    {
        audioSource.PlayOneShot(sideSound);
    }
}
