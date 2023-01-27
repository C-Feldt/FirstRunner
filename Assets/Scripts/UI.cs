using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    [SerializeField] private HeroCharacterController hero;
    [SerializeField] private GameObject startScreen;
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
                victoryScreen.SetActive(false);
                gameOverScreen.SetActive(false);
                break;
            case "Playing":
                startScreen.SetActive(true);
                victoryScreen.SetActive(false);
                gameOverScreen.SetActive(false);
                break;
            case "GameOver":
                startScreen.SetActive(false);
                victoryScreen.SetActive(false);
                gameOverScreen.SetActive(true);
                break;
            case "Victory":
                startScreen.SetActive(false);
                victoryScreen.SetActive(true);
                gameOverScreen.SetActive(false);
                break;
            default :
                
                break;
        }
    }
}
