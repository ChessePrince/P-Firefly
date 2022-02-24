using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSfx : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip shootClip;
    public AudioClip hurtClip;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayHurt()
    {
        audioSource.PlayOneShot(hurtClip, Random.Range(0.1f, 0.4f));
    }
    public void PlayShoot()
    {
        audioSource.PlayOneShot(shootClip, Random.Range(0.1f, 0.4f));
    }
}
