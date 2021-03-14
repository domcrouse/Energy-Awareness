using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, iInteract
{
    public int id;
    bool isOn = true;

    private void Start()
    {
    }
    public void Interact()
    {
        if (isOn)
        {
            GameEvents.current.TurnLightOff(id);
            isOn = false;
        }
        else 
        {
            GameEvents.current.TurnLightOn(id);
            isOn = true;
        }
    }
}
