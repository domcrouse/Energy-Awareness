﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour
{
    [Header("Components")]
    public NavMeshAgent agent;
    Animator anim;
    bool isInteractive = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        CameraControl.Instance.FocusOn(transform);
    }

    void FixedUpdate()
    {
        if (isInteractive && agent.remainingDistance < 0.6f)
        {
            isInteractive = false;
            agent.SetDestination(transform.position);
            InteractiveOptions.Instance.ShowOptions();
        }

        if (InteractionScript.clicked) { agent.destination = transform.position; return; }
        //Navigation for arrow keys
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            float horInput = Input.GetAxis("Horizontal");
            float verInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horInput, 0f, verInput);
            Vector3 moveDestination = transform.position + movement;
            agent.SetDestination(moveDestination);
        }
        //Navigation for mouse click
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if (hit.transform.tag == "Interactive") { isInteractive = true; }
                agent.destination = hit.point;
            }
        }
        anim.SetFloat("turn", Vector3.Dot(transform.right, agent.velocity));
        if (agent.remainingDistance > 0.6f) { anim.SetBool("moving", true); } else anim.SetBool("moving", false);
    }

}