using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimeText;
    private int mins;
    private int secs;

    private void Start()
    {
        mins = PlayerPrefs.GetInt("TimeMins");
        secs = PlayerPrefs.GetInt("TimeSecs");
    }
    private void Update()
    {
        TimeText.text = "Time taken to complete the game is " + mins.ToString() + " Minutes and " + secs.ToString() + " Seconds";
    }
}
