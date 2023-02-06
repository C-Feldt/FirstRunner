using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] private Transform target = null;       // Object to be followed (the player)
    [SerializeField] private HeroCharacterController hero;  // Hero's script for GameState management
    [SerializeField] private TextMeshProUGUI scoreText;     // The object that shows the text
    private int score = 0;
    private int highScore = 0;

    void Start()
    {
        
    }

    void Update()
    {
        score = (int) target.position.x / 2;
        scoreText.text = score.ToString();
        if(score > highScore)
        {
            highScore = score;
        }
    }

    public void resetHighscore()
    {
        highScore = 0;
    }

    public int getHighscore()
    {
        return highScore;
    }
}
