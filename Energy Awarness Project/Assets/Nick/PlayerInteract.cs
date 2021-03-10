using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    //Raycast. Attach to camera and will point where the player is looking
    RaycastHit hit;
    Vector3 fwd;
    public LayerMask ignore;

    private void Awake()
    {//Direction of raycast
        fwd = transform.TransformDirection(transform.forward);
    }
    void Update()
    {
        fwd = transform.TransformDirection(transform.forward);
        if (Physics.SphereCast(transform.position, 1, fwd, out hit, 10))
        {
            if (hit.collider.tag == "Interactive")
            {
            Debug.DrawRay(transform.position + transform.forward, fwd);
                if (hit.transform.gameObject.GetComponent<ObjectHighlight>())
                {
                    hit.transform.gameObject.GetComponent<ObjectHighlight>().Highlight();
                }

                if (Input.GetButtonDown("Fire1")) {
                    //This might not work. ??
                    iInteract interact = hit.transform.gameObject.GetComponentInChildren<iInteract>();
                    Debug.Log(hit.transform.gameObject);
                    if (interact != null)
                    {
                        interact.Interact();
                    } 

                }
            }
            

        }
    }
}
