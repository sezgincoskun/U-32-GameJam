using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    public AudioSource SFXManager1, SFXManager2;
    public AudioSource BGM;

    public AudioClip[] themeSongs;


    void Awake()
    {
        MakeSingleton();
        BGM.Play();
    }


    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame

    private void Update()
    {
        if (!BGM.isPlaying)
        {
            //BGM.clip = themeSongs[Random.Range(0, themeSongs.Length)];
            BGM.Play();
        }
    }

    public void PlaySoundFX(AudioClip audioClip, float volume)
    {
        if (!SFXManager1.isPlaying)
        {
            SFXManager1.clip = audioClip;
            SFXManager1.volume = volume;
            SFXManager1.PlayOneShot(audioClip, volume);
        }
        else
        {
            SFXManager2.clip = audioClip;
            SFXManager2.volume = volume;
            SFXManager2.PlayOneShot(audioClip, volume);
        }
    }

    public void PlayRandomSoundFX(AudioClip[] audioClips)
    {
        if (!SFXManager1.isPlaying)
        {
            SFXManager1.clip = audioClips[Random.Range(0, audioClips.Length)];
            SFXManager1.volume = Random.Range(0.3f, 0.6f);
            SFXManager1.Play();
        }
    }
}
