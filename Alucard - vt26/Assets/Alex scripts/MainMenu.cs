using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider MusicSlider;
    public Slider SFXSlider;

    public static int mapIndex;
    public void Start()
    {
        LoadVolume();
        MusicManager.Instance.PlayMusic("MainMenu");
        
    }
    public void Play()
    {
        SceneManager.LoadScene("MainGame");
        MusicManager.Instance.PlayMusic("MainGame");
    }
    public void PlayDirt()
    {
        mapIndex = 0;
        SceneManager.LoadScene("MainGame");
        MusicManager.Instance.PlayMusic("MainGame");
        Debug.Log("Selected Scifi Map " + mapIndex);
    }
    public void PlayScifi()
    {
        mapIndex = 1;
        SceneManager.LoadScene("MainGame");
        MusicManager.Instance.PlayMusic("MainGame");
        Debug.Log("Selected Scifi Map " + mapIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void UpdateSoundVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }

    public void SaveVolume()
    {
        audioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        audioMixer.GetFloat("SFXVolume", out float sfxVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    public void LoadVolume()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
}