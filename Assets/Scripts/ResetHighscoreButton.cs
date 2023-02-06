using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHighscoreButton : MonoBehaviour
{
    [SerializeField] private ScoreTracker scoreTracker;
    private AudioSource soundEffectClick;

    private void Start()
    {
        soundEffectClick = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        scoreTracker.resetHighscore();
        soundEffectClick.Play();
    }
}
