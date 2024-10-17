using UnityEngine.Audio;
using UnityEngine;
using System.ComponentModel;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public GameObject SFXPrefab;
    void Start()
    {
        instance = this;
    }

    public void PlaySFX(AudioClip clip, float volume)
    {
        GameObject obj = Instantiate(SFXPrefab);
        AudioSource audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = clip; // assigns clip to audio source game object
        audioSource.Play();
        audioSource.volume = volume;
        Destroy(obj, audioSource.clip.length); // destroys clip when the clip is done playing 
    }
}
