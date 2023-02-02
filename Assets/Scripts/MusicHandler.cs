using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script manages the music played within the game

public class MusicHandler : MonoBehaviour
{
    [SerializeField] private HeroCharacterController hero;  // Hero's script for GameState management
    [SerializeField] private AudioSource bgMusic;           // Background music track
    bool hasChangedState = false;                           // Check for whether the gameState has changed to "Playing"

    void Start()
    {
        
    }

    void Update()
    {
        string gameState = hero.gameState;  // Access gameState directly once, set to variable

        // Starts music when the gameState switches to "Playing", flips boolean to only run .Play() once
        if(gameState == "Playing" && !hasChangedState)
        {
            Debug.Log("Music Start");
            bgMusic.Play();
            hasChangedState = true;
        }
        else if(gameState != "Playing" && hasChangedState)
        {
            Debug.Log("Music End");
            bgMusic.Stop();
            hasChangedState = false;
        }
    }
}
