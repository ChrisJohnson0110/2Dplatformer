using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ensure a component audio source that will be played
/// </summary>
public class PlayMusicOnLoad : MonoBehaviour
{

    void Awake()
    {
        if (this.gameObject.GetComponent<AudioSource>() != null)
        {
            GameObject.FindObjectOfType<MusicManager>().SwitchToThisMusicTrack(this.gameObject.GetComponent<AudioSource>());
        }
    }
}
