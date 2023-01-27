using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgainButton : MonoBehaviour
{
    [SerializeField] private HeroCharacterController hero;
    [SerializeField] private Transform target;
    [SerializeField] private Transform cameraLocation;
    void Start()
    {
        
    }

    void Update()
    {
        string gameState = hero.gameState;

        if(gameState == "Victory")
        {
            transform.position = target.position + new Vector3(4, 1, 0);
        }
        else if(gameState == "GameOver")
        {
            transform.position = cameraLocation.position + new Vector3(0, -1, 6);
        }
        else
        {
            transform.position = new Vector3(0, -10, 0);
        }
    }

    private void OnMouseDown() {
        hero.characterController.enabled = false;
        hero.characterController.transform.position = new Vector3(0, 1, 0);
        hero.characterController.enabled = true;
        hero.gameState = "StartMenu";
        Debug.Log("Play Again Pressed");
    }
}
