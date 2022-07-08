using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenuManager : MonoBehaviour
{

    public void SetMusicVolume(float vol)
    {
        GlobalSoundManager.instance.SetMusicVolume(vol);
    }

    public void SetEffectsVolume(float vol)
    {
        GlobalSoundManager.instance.SetEffectsVolume(vol);

    }

}
