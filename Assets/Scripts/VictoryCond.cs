using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Detects when the player enters a Victory zone and changed the gameState accordingly
// Also plays a fancy little jingle

public class VictoryCond : MonoBehaviour
{
    [SerializeField] private HeroCharacterController hero;
    [SerializeField] private AudioSource victorySound;

    private void OnTriggerEnter(Collider other)
    {
        hero.gameState = "Victory";
        victorySound.Play();
    }
}
