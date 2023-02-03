using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonFromOptions : MonoBehaviour
{
    [SerializeField] private HeroCharacterController hero;  // Hero's script for GameState management

    private void OnMouseDown() {
        hero.gameState = "StartMenu";
    }
}
