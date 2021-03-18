using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderInteract : MonoBehaviour
{
    public bool isHolding = false;
    RaycastHit hit;
    Transform ladder;


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isHolding)
        {
            isHolding = false;
            Drop();
        }
        else if (Input.GetMouseButtonDown(0) && !isHolding)
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 20.0f))
            {

                if (hit.collider.tag == "Moveable")
                {
                    ladder = hit.transform;
                    isHolding = true;
                    PickUp();
                }
            }
        }
    }

    void PickUp()
    {
        hit.transform.gameObject.transform.parent = transform.parent;
        isHolding = true;
    }

    void Drop()
    {
        print("dropping object");
        hit.transform.gameObject.transform.parent = null;
        isHolding = false;
    }

}
