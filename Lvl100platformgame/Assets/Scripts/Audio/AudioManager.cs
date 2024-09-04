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

    public AudioSource audioSource; // Müzik çalacak AudioSource
    public AudioClip newMusicClip;
    public AudioClip oldMusicClip; // Yeni müzik klibi
    
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

    public void ChangeMusic()
    {
        // Eğer bir müzik çalıyorsa durdur
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); // Mevcut müziği durdur
        }

        // Yeni müzik klibini ata
        audioSource.clip = newMusicClip;

        // Yeni müziği çal
        audioSource.Play();
    }
    public void ChangeMusicAgain()
    {
        // Eğer bir müzik çalıyorsa durdur
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); // Mevcut müziği durdur
        }

        // Yeni müzik klibini ata
        audioSource.clip = oldMusicClip;

        // Yeni müziği çal
        audioSource.Play();
    }


}
