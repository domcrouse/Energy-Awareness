using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    //Raycast. Attach to camera and will point where the player is looking
    RaycastHit hit;
    Ray ray;
    public int layerMask;

    private void Awake()
    {//Direction of raycast
        layerMask = 1 << layerMask;
    }
    void Update()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        if (Physics.Raycast(ray,out hit,3, layerMask))
        {//Trying this again. It might work?
            Debug.DrawRay(Camera.main.transform.position, hit.point - Camera.main.transform.position);
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.transform.GetComponent<iInteract>() != null)
                {
                    hit.transform.GetComponent<iInteract>().Interact();
                }
            }
        }
    }
}
