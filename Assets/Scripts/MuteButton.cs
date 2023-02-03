using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButton : MonoBehaviour
{
    private void OnMouseDown() {
        if(AudioListener.pause == false)
        {
            AudioListener.pause = true;
            Debug.Log("Muted");
        }
        else
        {
            AudioListener.pause = false;
            Debug.Log("Unmuted");
        }
    }
}
