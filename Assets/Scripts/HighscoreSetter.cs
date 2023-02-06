using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreSetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highscoreText;     // The object that shows the text
    [SerializeField] private ScoreTracker scoreTracker;
    private int highscore;
    void Start()
    {
        
    }

    void Update()
    {
        highscore = scoreTracker.getHighscore();
        highscoreText.text = "HIGHSCORE:" + highscore.ToString();
    }
}
