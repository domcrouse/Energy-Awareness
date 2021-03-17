using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        float num = transform.eulerAngles.x;
        transform.LookAt(cam);
        transform.eulerAngles = new Vector3(num, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
