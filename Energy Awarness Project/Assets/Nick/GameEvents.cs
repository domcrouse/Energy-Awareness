using System;
using System.Collections.Generic;
using UnityEngine;

//Tutorial used: https://www.youtube.com/watch?v=gx0Lt4tCDE0
public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onZoomIn;
    public event Action onZoomOut;
    public void ZoomIn()
    {
        if (onZoomIn != null)
        {
            onZoomIn();
        }
    }
    public void ZoomOut()
    {
        if (onZoomOut != null)
        {
            onZoomOut();
        }
    }

    public event Action<int> onTurnLightOn;
    public void TurnLightOn(int id)
    {
        if (onTurnLightOn != null)
        {
            onTurnLightOn(id);
        }
    }

    public event Action<int> onTurnLightOff;
    public void TurnLightOff(int id)
    {
        if (onTurnLightOff != null)
        {
            onTurnLightOff(id);
        }
    }

}
