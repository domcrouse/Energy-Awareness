using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{

    public NavMeshAgent agent;
    Animator anim;
    bool isInteractive = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        CameraControl.Instance.FocusOn(transform);
    }

    // Update is called once per frame
    void Update()
    {

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

    }
}