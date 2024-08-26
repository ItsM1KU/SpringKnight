using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusic;

    private bool musicPaused = true;

    public void PauseMusicOnClick()
    {
        musicPaused = !musicPaused;

        if (musicPaused)
        {
            backgroundMusic.Pause();
        }
        else
        {
            backgroundMusic.Play();
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
