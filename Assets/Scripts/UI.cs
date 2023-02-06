using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script manages the various UI elements within the game
// Note: This is not exclusive to Unity-identified "UI", but also various in-world text elements used as UI

public class UI : MonoBehaviour
{

    [SerializeField] private HeroCharacterController hero;  // Hero's script for GameState management
    [SerializeField] private GameObject startScreen;        // The Start screen
    [SerializeField] private GameObject InstructionText;    // The text for the Instructions (ie, "Press Spacebar to Jump", etc...)
    [SerializeField] private GameObject victoryScreen;      // The Victory screen
    [SerializeField] private GameObject gameOverScreen;     // The Game Over screen
    [SerializeField] private GameObject scoreText;          // The score UI
    [SerializeField] private GameObject highscoreText;      // The highscore UI

    void Start()
    {
        
    }

    void Update()
    {
        string gameState = hero.gameState;

        // Manages UI based on current gameState
        // Note: Play Again button not included due to use in multiple screens
        switch (gameState) {
            case "StartMenu":
                startScreen.SetActive(true);
                InstructionText.SetActive(false);
                victoryScreen.SetActive(false);
                gameOverScreen.SetActive(false);
                scoreText.SetActive(false);
                highscoreText.SetActive(false);
                break;
            case "Options":
                startScreen.SetActive(true);
                InstructionText.SetActive(false);
                victoryScreen.SetActive(false);
                gameOverScreen.SetActive(false);
                scoreText.SetActive(false);
                highscoreText.SetActive(false);
                break;
            case "Instructions":
                startScreen.SetActive(true);
                InstructionText.SetActive(true);
                victoryScreen.SetActive(false);
                gameOverScreen.SetActive(false);
                scoreText.SetActive(false);
                highscoreText.SetActive(false);
                break;
            case "Playing":
                startScreen.SetActive(true);
                InstructionText.SetActive(true);
                victoryScreen.SetActive(false);
                gameOverScreen.SetActive(false);
                scoreText.SetActive(true);
                highscoreText.SetActive(false);
                break;
            case "Victory":
                startScreen.SetActive(false);
                InstructionText.SetActive(false);
                victoryScreen.SetActive(true);
                gameOverScreen.SetActive(false);
                scoreText.SetActive(true);
                highscoreText.SetActive(true);
                break;
            case "GameOver":
                startScreen.SetActive(false);
                InstructionText.SetActive(false);
                victoryScreen.SetActive(false);
                gameOverScreen.SetActive(true);
                scoreText.SetActive(true);
                highscoreText.SetActive(true);
                break;
            default :
                
                break;
        }
    }
}
