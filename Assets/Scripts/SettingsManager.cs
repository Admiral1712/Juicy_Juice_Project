using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;

    public float musicVolume { get; private set; } = 1.0f;
    public float soundVolume { get; private set; } = 1.0f;
    public float mouseSensitivity { get; private set; } = 100.0f;

    public Resolution[] resolutions;
    public int currentResolutionIndex = -1;
    public int currentQualityIndex = -1;

    public bool fullScreen = true;

    void Awake()
    {
        if (instance == null)
            instance = this;

        Load();

        resolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == 60).ToArray();
    }

    public void ChangeMusicVolume(float value)
    {
        musicVolume = value;
        Save();
    }

    public void ChangeSoundVolume(float value)
    {
        soundVolume = value;
        Save();
    }

    public void ChangeMouseSensitivity(float value)
    {
        mouseSensitivity = value;
        Save();
    }

    void Load()
    {
        musicVolume = PlayerPrefs.HasKey("musicVolume") ? PlayerPrefs.GetFloat("musicVolume") : 0.5f;
        soundVolume = PlayerPrefs.HasKey("soundVolume") ? PlayerPrefs.GetFloat("soundVolume") : 0.5f;
        mouseSensitivity = PlayerPrefs.HasKey("mouseSensitivity") ? PlayerPrefs.GetFloat("mouseSensitivity") : 100.0f;

        currentResolutionIndex = PlayerPrefs.HasKey("currentResolutionIndex") ? PlayerPrefs.GetInt("currentResolutionIndex") : -1;
        currentQualityIndex = PlayerPrefs.HasKey("currentQualityIndex") ? PlayerPrefs.GetInt("currentQualityIndex") : -1;

        fullScreen = PlayerPrefs.HasKey("fullScreen") ? PlayerPrefs.GetInt("fullScreen") == 1 : true;
    }

    void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("soundVolume", soundVolume);
        PlayerPrefs.SetFloat("mouseSensitivity", mouseSensitivity);

        PlayerPrefs.SetInt("currentResolutionIndex", currentResolutionIndex);
        PlayerPrefs.SetInt("currentQualityIndex", currentQualityIndex);

        PlayerPrefs.SetInt("fullScreen", fullScreen ? 1 : 0);

        PlayerPrefs.Save();
    }

    public void SetResolution(int resolutionIndex)
    {
        currentResolutionIndex = resolutionIndex;
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        Save();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Save();
    }

    public void SetQuality(int qualityIndex)
    {
        currentQualityIndex = qualityIndex;
        Debug.Log(qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex);
        Save();
    }
}
