using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverPoster : MonoBehaviour, iInteract
{
    int posterNum = 0;
    private void Start()
    {
        GameEvents.current.onPickUpPoster += AddPoster;
    }
    private void OnDisable()
    {
        GameEvents.current.onPickUpPoster -= AddPoster;
    }
    public void Interact()
    {
        GameEvents.current.DeliverPoster(posterNum);
        posterNum = 0;
    }

    void AddPoster()
    {
        posterNum++;
    }
}
