using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script manages the camera's behavior and positioning

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target = null;       // Object to be followed (Usually, the player)
    [SerializeField] private float xOffset = 5;             // Offset from the character on the x-axis
    [SerializeField] private HeroCharacterController hero;  // Hero's script for GameState management

    private Vector3 offset;                                 // Difference from camera's position to target's position

    void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        string gameState = hero.gameState;  // Access gameState directly once, set to variable

        // Different behaviors based on current GameState
        if(gameState == "Playing" || gameState == "GameOver" || gameState == "Victory")
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x + xOffset, 3f, -10f) + offset, Time.deltaTime * 3);
        }
        else if(gameState == "StartMenu")
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-1.5f, 1f, -4f) + offset, Time.deltaTime * 3);
        }
        else if(gameState == "Instructions")
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(2f, 1f, -4f) + offset, Time.deltaTime * 3);
        }
    }
}
