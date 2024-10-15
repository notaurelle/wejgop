using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range (0f, 1f)] // sets range for volume slider
    public float volume;
    [Range(.1f, 3f)]// sets range for pitch slider
    public float pitch;
}
