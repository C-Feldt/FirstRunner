using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MuteButton : MonoBehaviour
{
    private AudioSource soundEffectClick;
    [SerializeField] private TextMeshPro optionText;     // The object that shows the text

    private void Start()
    {
        soundEffectClick = GetComponent<AudioSource>();
    }

    private void OnMouseDown() {
        if(AudioListener.pause == false)
        {
            AudioListener.pause = true;
            Debug.Log("Muted");
            optionText.text = "Muted";
        }
        else
        {
            AudioListener.pause = false;
            Debug.Log("Unmuted");
            soundEffectClick.Play();
            optionText.text = "Unmuted";
        }
    }
}
