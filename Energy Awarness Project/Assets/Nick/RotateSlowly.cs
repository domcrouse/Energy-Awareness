using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSlowly : MonoBehaviour
{
    public float rotateSpeed = 1;
    Quaternion rot;
    private void Awake()
    {
        rot = transform.rotation;
    }

    private void FixedUpdate()
    {
        transform.Rotate(rot.eulerAngles.x,rot.eulerAngles.y + rotateSpeed,rot.eulerAngles.z);
    }
}
