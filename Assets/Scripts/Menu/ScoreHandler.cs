using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public TextMeshProUGUI score;



    void Start()
    {
        int scoreCalculator;
        Cursor.lockState = CursorLockMode.None;
        if(PlayerPrefs.GetInt("TimeLeft") > 0)
        {
            scoreCalculator = 500000 / (PlayerPrefs.GetInt("Moves") + 1);
            scoreCalculator += 5000 * PlayerPrefs.GetInt("TimeLeft");
        } else
        {
            scoreCalculator = 0;
        }
        

        score.text = scoreCalculator.ToString();
    }

   
}
