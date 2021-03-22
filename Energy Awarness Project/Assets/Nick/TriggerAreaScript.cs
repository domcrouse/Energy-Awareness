using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaScript : MonoBehaviour
{
    public iInteract interact;
    bool isInRange;
    private void Awake()
    {
        interact = transform.parent.gameObject.GetComponentInChildren<iInteract>();
    }
    private void Update()
    {
        if (isInRange)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                //This might not work. ??
                if (interact != null)
                {
                    interact.Interact();
                }
                else { Debug.Log("No Interact found"); }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    { 
        if (other.tag == "Player")
        {
            isInRange = false;
        }
    }
    
}
