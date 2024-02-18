using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public float MusicVolume;

    AudioSource CurrentMusic;


    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SwitchToThisMusicTrack(AudioSource a_acMusicToSwitchTo)
    {
        if (CurrentMusic != null)
        {
            CurrentMusic.Stop();
        }
        CurrentMusic = a_acMusicToSwitchTo;
        CurrentMusic.volume = MusicVolume;
        CurrentMusic.Play();
    }


}