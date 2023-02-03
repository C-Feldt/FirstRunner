using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    [SerializeField] private HeroCharacterController hero;  // Hero's script for GameState management

    private void OnMouseDown() {

        // Changes gameState to "Instructions" when the Play Button is pressed
        hero.gameState = "Options";

    }
}
