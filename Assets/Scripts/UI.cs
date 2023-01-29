using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    [SerializeField] private HeroCharacterController hero;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject InstructionText;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject gameOverScreen;

    void Start()
    {
        
    }

    void Update()
    {
        string gameState = hero.gameState;

        switch (gameState) {
            case "StartMenu":
                startScreen.SetActive(true);
                InstructionText.SetActive(false);
                victoryScreen.SetActive(false);
                gameOverScreen.SetActive(false);
                break;
            case "Instructions":
                startScreen.SetActive(true);
                InstructionText.SetActive(true);
                victoryScreen.SetActive(false);
                gameOverScreen.SetActive(false);
                break;
            case "Playing":
                startScreen.SetActive(true);
                InstructionText.SetActive(true);
                victoryScreen.SetActive(false);
                gameOverScreen.SetActive(false);
                break;
            case "Victory":
                startScreen.SetActive(false);
                InstructionText.SetActive(false);
                victoryScreen.SetActive(true);
                gameOverScreen.SetActive(false);
                break;
            case "GameOver":
                startScreen.SetActive(false);
                InstructionText.SetActive(false);
                victoryScreen.SetActive(false);
                gameOverScreen.SetActive(true);
                break;
            default :
                
                break;
        }
    }
}
