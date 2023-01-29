using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private float xOffset = 5;
    
    [SerializeField] private HeroCharacterController hero;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        string gameState = hero.gameState;

        if(gameState == "Playing")
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x + xOffset, 3f, -10f) + offset, Time.deltaTime * 3);
        }
        else if(gameState == "StartMenu")
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-1.5f, 1f, -4f) + offset, Time.deltaTime * 3);
        }
        else if(gameState == "GameOver")
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x + xOffset, 3f, -10f) + offset, Time.deltaTime * 3);
        }
        else if(gameState == "Victory")
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x + xOffset, 3f, -10f) + offset, Time.deltaTime * 3);
        }
        else if(gameState == "Instructions")
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(2f, 1f, -4f) + offset, Time.deltaTime * 3);
        }
    }
}
