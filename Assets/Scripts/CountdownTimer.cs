using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 900f;
    public GameManager gameManager;

    [SerializeField] TextMeshProUGUI countdownText;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        countdownText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

        if(currentTime <= 0)
        {
            PlayerPrefs.SetInt("TimeLeft", 0);
            gameManager.wonGame();
            currentTime = 0;

        }
    }

    public int getTime()
    {
        return (int)currentTime;
    }
}
