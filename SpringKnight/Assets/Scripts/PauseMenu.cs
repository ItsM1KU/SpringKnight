using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausemenu;
    [SerializeField] AudioSource bgMusic;

    private bool isPaused = false;
    private bool musicPaused = true;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        pausemenu.SetActive(false);
    }

    private void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        pausemenu.SetActive(true);
    }

    public void MenuChange()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }

    public void PauseMusicOnClick()
    {
        musicPaused = !musicPaused;

        if (musicPaused)
        {
            bgMusic.Pause();
        }
        else
        {
            bgMusic.Play();
        }

    }
}
