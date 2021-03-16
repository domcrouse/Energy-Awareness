using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPoster : MonoBehaviour, iInteract
{
    public GameObject tip;
    public string tipText;
    private void Awake()
    {
        tip.GetComponentInChildren<TMPro.TMP_Text>().text = tipText;
    }
    public void Interact()
    {
        GameEvents.current.PickUpPoster();
        tip.SetActive(false);
        gameObject.SetActive(false);
    }
}
