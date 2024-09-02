using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioSource[] sounds;

    public Slider musicSlider, sfxSlider;

    public AudioMixer audioMixer;
    public AudioMixer sfxMixer;
    private void Awake()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            
            if (currentSceneName != "Main Menu")
            {
                DontDestroyOnLoad(gameObject);
            }
            

        }
    }
    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }
    public void PlaySound(int index)
    {
        sounds[index].Play();
    }

    public void MusicValue(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }
    public void SFXValue(float volume)
    {
        sfxMixer.SetFloat("sfx", volume);
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
    }
}
