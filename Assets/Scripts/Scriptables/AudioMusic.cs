using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioMusic", menuName = "Audio/New Audio Music")]
public class AudioMusic : ScriptableObject
{
    public AudioClip clip;
    public bool isPlaying;
    public bool isPaused;
    public bool isStopped;
    public bool isLooping;
    public bool looping;
    public float volume;
    public float pitch;
    public float roll;
}
