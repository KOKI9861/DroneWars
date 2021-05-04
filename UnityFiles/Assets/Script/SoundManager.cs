using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] bgmSound;
    public AudioClip[] effectSound;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.inGame == false && audioSource.clip != bgmSound[0])
        {
            audioSource.clip = bgmSound[0];
            if (audioSource.isPlaying == false)
            {
                audioSource.Play();
            }
        }
        else if (GameManager.inGame == true && audioSource.clip != bgmSound[1])
        {
            audioSource.clip = bgmSound[1];
            if (audioSource.isPlaying == false)
            {
                audioSource.Play();
            }
        }
    }
}
