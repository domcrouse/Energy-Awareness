using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, iInteract
{
    public int id;
    public int power;
    bool isOn = true;

    private void Start()
    {
        UIProgressBar.Instance.AddToMax(power);
        UIProgressBar.Instance.ChangeAmount(power);
        GoalManager.current.ChangeCurrentGoalNum(Goal.goalType.EnergyLevel, power);
    }
    public void Interact()
    {
        if (isOn)
        {
            GameEvents.current.TurnLightOff(id);
            GoalManager.current.ChangeCurrentGoalNum(Goal.goalType.EnergyLevel, -power);
            UIProgressBar.Instance.ChangeAmount(-power);
            isOn = false;
        }
        else 
        {
            GameEvents.current.TurnLightOn(id);
            GoalManager.current.ChangeCurrentGoalNum(Goal.goalType.EnergyLevel, power);
            UIProgressBar.Instance.ChangeAmount(power);
            isOn = true;
        }
    }
}
