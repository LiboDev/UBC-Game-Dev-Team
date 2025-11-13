using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;

    private float sfxVolume;
    private float musicVolume;

    private void Start()
    {
        //destroy self if audio manager already exists in scene
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        

        Debug.Log("set volume");

        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1);

        //setting volume when new scene loaded
        SFXVolume(sfxVolume);
        MusicVolume(musicVolume);

        //set value on sliders
        sfxSlider.value = sfxVolume;
        musicSlider.value = musicVolume;
    }

    //set audio mixer volume
    public void SFXVolume(float volume)
    {
        if (volume <= Mathf.Pow(10, -80))
        {
            audioMixer.SetFloat("SFX", -80f);
            PlayerPrefs.SetFloat("SFXVolume", -80f);
            return;
        }

        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);

        Debug.Log(volume);
    }

    public void MusicVolume(float volume)
    {
        if (volume <= Mathf.Pow(10, -80))
        {
            audioMixer.SetFloat("Music", -80f);
            PlayerPrefs.SetFloat("MusicVolume", -80f);
            return;
        }

        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);

        Debug.Log(volume);
    }
}

//example of how to play sfx

// [SerializeField] private Sound[] sounds;
// this allows sound effects to be set in scene editor, with names

//plays sfx with given name
/*private void PlaySFX(string name, float variation, float volume)
{
    Sound s = null;

    for (int i = 0; i < sounds.Length; i++)
    {
        if (sounds[i].name == name)
        {
            s = sounds[i];
        }
    }

    audioSource.pitch = Random.Range(1f - variation, 1f + variation);

    if (s == null)
    {
        Debug.LogError("SoundNotFound");
    }
    else
    {
        audioSource.PlayOneShot(s.clip, volume);
    }
}*/