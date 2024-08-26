using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusic;

    private bool musicPaused = false;

    public void PauseMusicOnClick()
    {
        musicPaused = !musicPaused;

        if (musicPaused)
        {
            backgroundMusic.Play();
        }
        else
        {
            backgroundMusic.Pause();
        }

    }

    public void playGame()
    {
        SceneManager.LoadScene("Test");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
