using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    //Raycast. Attach to camera and will point where the player is looking
    RaycastHit hit;
    Vector3 fwd;

    private void Awake()
    {//Direction of raycast
        fwd = transform.TransformDirection(Vector3.forward);
    }
    void Update()
    {
        if (Physics.Raycast(transform.position, fwd,out hit, 10))
        {
            if (hit.transform.gameObject.GetComponent<ObjectHighlight>())
            {
                hit.transform.gameObject.GetComponent<ObjectHighlight>().Highlight();
            }

            if (Input.GetButton("Fire1")) {
                //This might not work. ??
                iInteract interact = hit.transform.gameObject.GetComponent<iInteract>();
                if (interact != null)
                {
                    interact.Interact();
                } 
            }
        }
    }
}
