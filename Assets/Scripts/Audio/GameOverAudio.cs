using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameOverAudio : MonoBehaviour
{
    public AudioSource ambienceSong;

    void Start()
    {
        
        ambienceSong.Stop();
    }
}


