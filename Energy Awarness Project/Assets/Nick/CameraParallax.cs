using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraParallax : MonoBehaviour
{
    Transform player;
    Vector3 initialPosotion;
    Vector3 camPos;
    public float movementFactor = 0.01f;
    private void Awake()
    {
        player = FindObjectOfType<MovementController>().transform;
        initialPosotion = player.position;
        camPos = transform.position;
    }
    private void FixedUpdate()
    {
        transform.position = camPos + ((player.position-initialPosotion)* -movementFactor);
    }
}
