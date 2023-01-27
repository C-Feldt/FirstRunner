using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCond : MonoBehaviour
{
    [SerializeField] private HeroCharacterController hero;

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        hero.gameState = "Victory";
        
    }
}
