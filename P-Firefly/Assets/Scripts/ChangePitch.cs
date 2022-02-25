using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangePitch : MonoBehaviour
{
    AudioSource audioSource;
    int buildIndex;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //buildIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        switch (buildIndex)
        {
            case 0:
                audioSource.pitch = 0.5f;
                break;
            case 1:
                audioSource.pitch = 1f;
                LowerVolume();
                break;
        }
    }
    void LowerVolume()
    {
        if (PauseControl.gameIsPaused)
            audioSource.volume = 0.1f;
        else
            audioSource.volume = 0.2f;
    }
}
