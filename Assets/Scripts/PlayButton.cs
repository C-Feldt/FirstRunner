using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{

    [SerializeField] private HeroCharacterController hero;

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnMouseDown() {
        hero.gameState = "Playing";
    }
}
