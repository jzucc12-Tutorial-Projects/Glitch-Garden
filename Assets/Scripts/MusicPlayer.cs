using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource myAudioSource;

    void Start()
    {
        DontDestroyOnLoad(this);
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void SetVolume(float volume)
    {
        myAudioSource.volume = volume;
    }
}
