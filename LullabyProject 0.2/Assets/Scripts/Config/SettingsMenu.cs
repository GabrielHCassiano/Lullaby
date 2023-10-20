using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using UnityEngine.Rendering.Universal;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Slider sliderMaster;
    public Slider sliderMusic;
    public Slider sliderEffects;
    public Slider sliderBrilho;
    public Toggle toggle;
    public Dropdown dropResulution;
    public Dropdown dropQuality;
    public Dropdown dropQuality1;
    public Dropdown dropLocation;
    public Light2D global;


    void Start()
    {
        sliderMaster.value = PlayerPrefs.GetFloat("Master", 0.5f);
        sliderMusic.value = PlayerPrefs.GetFloat("Music", 0.5f);
        sliderEffects.value = PlayerPrefs.GetFloat("Effects", 0.5f);
        sliderBrilho.value = PlayerPrefs.GetFloat("Brilho", 0.5f);
        global.intensity = sliderBrilho.value / 3.5f;
        toggle.isOn = PlayerPrefs.GetInt("Full") != 1;
        dropResulution.value = PlayerPrefs.GetInt("Resolution");
        dropQuality.value = PlayerPrefs.GetInt("Quality", 2);
        dropQuality1.value = PlayerPrefs.GetInt("Quality", 2);
        dropLocation.value = PlayerPrefs.GetInt("Location", 0);
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[dropLocation.value];
    }

    private void Update()
    {
        if(dropLocation.value == 0)
        {
            dropQuality.gameObject.SetActive(true);
            dropQuality1.gameObject.SetActive(false);
        }
        else
        {
            dropQuality.gameObject.SetActive(false);
            dropQuality1.gameObject.SetActive(true);
        }
    }

    public void SetMaster (float volume)
  {
        PlayerPrefs.SetFloat("Master", volume);
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
  }

  public void SetMusic(float volume)
  {
        PlayerPrefs.SetFloat("Music", volume);
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
  }
  public void SetEffects(float volume)
  {
        PlayerPrefs.SetFloat("Effects", volume);
        audioMixer.SetFloat("Effects", Mathf.Log10(volume) * 20);
  }

  public void SetBrightness(float brilho)
    {
        PlayerPrefs.SetFloat("Brilho", brilho);
        //global.intensity.SetFloat("Brilho", brilho/2);
        global.intensity = brilho / 3.5f;
   }

   public void SetQuality (int qualityIndex)
  {
        PlayerPrefs.SetInt("Quality", qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex);
    }

  public void SetFullScreen (bool isFullscreen)
  {
        PlayerPrefs.SetInt("Full", isFullscreen? 0 : 1);
        Screen.fullScreen = isFullscreen;
  }

    public void SetResolution(int resolution)
    {

        PlayerPrefs.SetInt("Resolution", resolution);

        switch (resolution)
        {
            case 0: Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 1: Screen.SetResolution(1360, 796, Screen.fullScreen);
                break;
            case 2: Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
            case 3: Screen.SetResolution(1152, 648, Screen.fullScreen);
                break;
            case 4:
                Screen.SetResolution(960, 540, Screen.fullScreen);
                break;
        }
    }

    public void SetLocation(int location)
    {
        dropQuality.value = PlayerPrefs.GetInt("Quality", 2);
        dropQuality1.value = PlayerPrefs.GetInt("Quality", 2);
        PlayerPrefs.SetInt("Location", location);

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[location];
        
    }
}
