using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script manages the trails emitted by the player as they move
// It toggles the trails on and off at random intervals to create a windy effect.

public class RandomTrailsEmit : MonoBehaviour
{
    private TrailRenderer trailRenderer;    // The renderer for the trail shown as the player runs
    private float duration;                 // How long the trail will show for
    private float timestamp;                // The time the trail was changed

    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        if(Time.time > timestamp + duration)
        {
            duration = Random.Range(0.05f, 0.3f);
            timestamp = Time.time;
            trailRenderer.emitting = !trailRenderer.emitting;
        }
    }
}
