using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSoundManager : MonoBehaviour
{
    public static GlobalSoundManager instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private float musicVolume = 0.8f;

    private float effectsVolume = 0.8f;



    public void SetMusicVolume(float vol)
    {
        musicVolume = vol;
        Debug.Log("Volume changed to: " + vol);
    }

    public void SetEffectsVolume(float vol)
    {
        effectsVolume = vol;
        Debug.Log("Volume changed to: " + vol);

    }
}
