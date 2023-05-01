using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTransition : MonoBehaviour
{
    public AudioMixerSnapshot snapshot;
    public float transiotionTime = .1f;

    public void MakeTransition()
    {
        snapshot.TransitionTo(transiotionTime);
    }
}
