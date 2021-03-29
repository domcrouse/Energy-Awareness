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
    public event Action<int> onChangeLightbulb;
    public void ChangeLightbulb(int id)
    {
        if (onChangeLightbulb != null)
        {
            onChangeLightbulb(id);
        }
    }
    public event Action<int> onSwitchLightbulb;
    public void SwitchLightbulb(int id)
    {
        if (onSwitchLightbulb != null)
        {
            onSwitchLightbulb(id);
        }
    }

    public event Action onPickUpPoster;
    public void PickUpPoster()
    {
        if (onPickUpPoster != null)
        {
            onPickUpPoster();
        }
    }
    public event Action<int> onDeliverPoster;
    public void DeliverPoster(int amount)
    {
        if (onDeliverPoster != null)
        {
            onDeliverPoster(amount);
        }
    }
    public event Action<int> onUnlockDoor;
    public void UnlockDoor(int id)
    {
        if(onUnlockDoor != null)
        {
            onUnlockDoor(id);
        }
    }
    public event Action<int> onChangeTemp;
    public void ChangeTemp(int amount)
    {
        if(onChangeTemp!= null)
        {
            onChangeTemp(amount);
        }
    }
    public event Action onLeaveRoom;
    public void LeaveRoom()
    {
        if (onLeaveRoom != null)
        {
            onLeaveRoom();
        }
    }
    public event Action onCorrectAnswer;
    public void CorrectAnswer()
    {
        if (onCorrectAnswer != null)
        {
            onCorrectAnswer();
        }
    }
    public event Action onIncorrectAnswer;
    public void IncorrectAnswer()
    {
        if (onIncorrectAnswer != null)
        {
            onIncorrectAnswer();
        }
    }
    public event Action onCountScore;
    public void CountScore()
    {
        if (onCountScore != null)
        {
            onCountScore();
        }
    }
}
