using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script manages the behavior of the Play text

public class PlayButton : MonoBehaviour
{

    [SerializeField] private HeroCharacterController hero;  // Hero's script for GameState management

    private void OnMouseDown() {

        // Changes gameState to "Instructions" when the Play Button is pressed
        hero.gameState = "Instructions";

    }
}
