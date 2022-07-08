using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;


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


    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
