using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPoster : MonoBehaviour, iInteract
{
    public void Interact()
    {
        GameEvents.current.PickUpPoster();
        gameObject.SetActive(false);
    }
}
