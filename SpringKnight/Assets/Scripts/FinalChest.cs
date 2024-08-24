using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalChest : MonoBehaviour
{

    private Animator anim;
    [SerializeField] TextMeshProUGUI timerText;
    private float elapsedTime;
    private int minutes;
    private int seconds;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        minutes = Mathf.FloorToInt(elapsedTime / 60);
        seconds = Mathf.FloorToInt(elapsedTime % 60);
        //timerText.text = minutes.ToString() + ":" +  seconds.ToString();
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("isOpening", true);
            SceneManager.LoadScene("EndScene");
            PlayerPrefs.SetInt("TimeMins", minutes);
            PlayerPrefs.SetInt("TimeSecs", seconds);
        }
    }
}
