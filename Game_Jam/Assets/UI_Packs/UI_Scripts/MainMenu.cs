using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    public GameObject SettingsPanel;
    public GameObject PausePanel;

    public void PlayGame()
    {
        LevelManager.Instance.LoadScene("TestTransition", "CrossFade");
        SoundManager.Instance.PlaySound2D("Buttons");
        Debug.Log("super mario");
    }
    public void LoadLevels(string LevelName)
    {
        LevelManager.Instance.LoadScene(LevelName, "CrossFade");
        SoundManager.Instance.PlaySound2D("Buttons");
    }
    public void LoadLevelScenes()//loading the level in level scene(eg. 1 2 3)
    {
        LevelManager.Instance.LoadScene("UI_Levels", "CrossFade");
    }
    public void SettingPanel()//enabling setting panel
    {
        SettingsPanel.SetActive(true);
        SoundManager.Instance.PlaySound2D("Buttons");
    }
    public void PauseMenu()//enabling the pause menu
    {
        PausePanel.SetActive(true);
        SoundManager.Instance.PlaySound2D("Buttons");
    }
    public void BackOfPauseMenu()//disabling pausse menu
    {
        PausePanel.SetActive(false);
        SoundManager.Instance.PlaySound2D("Buttons");
    }
    public void BackOfSettings()//disabling setting panel
    {
        SettingsPanel.SetActive(false);
        SoundManager.Instance.PlaySound2D("Buttons");
    }
    public void QuitGame()
    {
        // LevelManager.Instance.();
        Application.Quit();
        SoundManager.Instance.PlaySound2D("Buttons");
    }
    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MUSICK", volume);
    }
 
    public void UpdateSoundVolume(float volume)
    {
        audioMixer.SetFloat("SFX", volume);
    }
 
    public void SaveVolume()
    {
        audioMixer.GetFloat("MUSICK", out float musicVolume);
        // audioMixer.GetFloat)
        PlayerPrefs.SetFloat("MUSICK", musicVolume);
 
        audioMixer.GetFloat("SFX", out float sfxVolume);
        PlayerPrefs.SetFloat("SFX", sfxVolume);
    }
 
    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MUSICK");
        sfxSlider.value = PlayerPrefs.GetFloat("SFX");
    }
}
