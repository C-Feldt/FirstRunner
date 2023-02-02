using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script manages the behavior and positioning of the PlayAgain button

public class PlayAgainButton : MonoBehaviour
{
    [SerializeField] private HeroCharacterController hero;  // Hero's script for GameState management
    [SerializeField] private Transform target;              // Object to be followed (the player)
    [SerializeField] private Transform cameraLocation;      // The camera's location
    void Start()
    {
        
    }

    void Update()
    {
        string gameState = hero.gameState;

        // Move PlayAgain position based on the current gameState
        if(gameState == "Victory")
        {
            transform.position = target.position + new Vector3(4, 1, 0);            // Move next to the character
        }
        else if(gameState == "GameOver")
        {
            transform.position = cameraLocation.position + new Vector3(0, -1, 6);   // Move to the center of the screen
        }
        else
        {
            transform.position = new Vector3(0, -10, 0);                            // Move to non-visible locaiton
        }
    }

    private void OnMouseDown() {

        // Moves the character to the start again
        hero.characterController.enabled = false;
        hero.characterController.transform.position = new Vector3(0, 1, 0);
        hero.characterController.enabled = true;

        // Change gameState to StartMenu
        hero.gameState = "StartMenu";
        Debug.Log("Play Again Pressed");
    }
}
