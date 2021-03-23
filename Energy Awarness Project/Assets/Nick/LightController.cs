using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightController : MonoBehaviour
{
    public int id;
    public int energy;
    [Range(0.1f, 1)]
    public float energyMultiplyerLED;
    [Range(0, 1)]
    public float lightOffValue = 0.2f;
    Light lamp;
    public float lightOnVal = 7;
    public Color standardColor;
    public Color LEDColor;

    public static int score;

    private void Start()
    {
        GameEvents.current.onTurnLightOn += OnLightOn;
        GameEvents.current.onTurnLightOff += OnLightOff;
        lamp = GetComponent<Light>();
        lamp.color = standardColor;
        UIProgressBar.Instance.AddToMax(energy);
        UIProgressBar.Instance.ChangeAmount(energy);
        GoalManager.current.ChangeCurrentGoalNum(Goal.goalType.EnergyLevel, energy);
    }
    void OnLightOn(int id)
    {
        if (id == this.id)
        {
            lamp.intensity = lightOnVal;
            GoalManager.current.ChangeCurrentGoalNum(Goal.goalType.LightsOff, -1);
            GoalManager.current.ChangeCurrentGoalNum(Goal.goalType.EnergyLevel, energy);
            UIProgressBar.Instance.ChangeAmount(energy);
            score -= TimeLimit.current.TimeModifiedScore(5);
        }
    }
    void OnLightOff(int id)
    {
        if (id == this.id)
        {
            lamp.intensity = lightOffValue;
            GoalManager.current.ChangeCurrentGoalNum(Goal.goalType.LightsOff, 1);
            GoalManager.current.ChangeCurrentGoalNum(Goal.goalType.EnergyLevel, -energy);
            UIProgressBar.Instance.ChangeAmount(-energy);
            score += TimeLimit.current.TimeModifiedScore(5);
        }
    }

    public void SwitchToLED()
    {
        GameEvents.current.SwitchLightbulb(0);
        if (lamp.intensity == lightOffValue) { }
        else
        {
            GoalManager.current.ChangeCurrentGoalNum(Goal.goalType.EnergyLevel, -energy);
            UIProgressBar.Instance.ChangeAmount(-energy);
            UIProgressBar.Instance.AddToMax(-energy);
        }
        energy = Mathf.CeilToInt(energy * energyMultiplyerLED);
        lamp.color = LEDColor; if (lamp.intensity == lightOffValue) { }
        else
        {
            GoalManager.current.ChangeCurrentGoalNum(Goal.goalType.EnergyLevel, energy);
            UIProgressBar.Instance.ChangeAmount(energy);
            UIProgressBar.Instance.AddToMax(energy);
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.onTurnLightOn -= OnLightOn;
        GameEvents.current.onTurnLightOff -= OnLightOff;
    }
}
