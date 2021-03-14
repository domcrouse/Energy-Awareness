using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTemp : MonoBehaviour, iInteract
{
    public int amountToChange;
    public void Interact()
    {
        GameEvents.current.ChangeTemp(amountToChange);
    }
}
