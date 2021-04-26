using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    SettingsManager sm = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        sm = SettingsManager.instance;
    }

    public void PlaySoundAt(AudioClip audio, Vector3 position) => PlaySoundAt(audio, position, 1.0f);

    public void PlaySoundAt(AudioClip audio, Vector3 position, float baseVolume)
    {
        AudioSource.PlayClipAtPoint(audio, position, baseVolume * sm.soundVolume);
    }
}
