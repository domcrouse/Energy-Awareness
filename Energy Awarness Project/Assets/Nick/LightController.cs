using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightController : MonoBehaviour
{
    public int id;
    [Range(0, 1)]
    public float lightOffValue = 0.2f;
    Light lamp;
    private void Start()
    {
        GameEvents.current.onTurnLightOn += OnLightOn;
        GameEvents.current.onTurnLightOff += OnLightOff;
        lamp = GetComponent<Light>();
    }
    void OnLightOn(int id)
    {
        if (id == this.id)
        {
            lamp.intensity = 1;
        }
    }
    void OnLightOff(int id)
    {
        if (id == this.id)
        {
            lamp.intensity = lightOffValue;
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.onTurnLightOn -= OnLightOn;
        GameEvents.current.onTurnLightOff -= OnLightOff;
    }
}
