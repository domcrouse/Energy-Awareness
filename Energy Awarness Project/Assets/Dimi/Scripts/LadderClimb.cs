using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    public MovementController playerObject;
    public bool canClimb = false;
    public float speed = 1;


    

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            canClimb = true;
            playerObject.isClimbing = true;
        }
    }

    void OnTriggerExit(Collider col2)
    {
        if (col2.tag == "Player")
        {
            canClimb = false;
            playerObject.isClimbing = false;
        }
    }
    void Update()
    {
        if (canClimb)
        {
            if (Input.GetKey(KeyCode.W))
            {
                playerObject.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerObject.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
            }
        }
    }
}
