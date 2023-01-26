using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private float xOffset = 5;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x + xOffset, 0, target.position.z) + offset, Time.deltaTime * 3);
    }
}
