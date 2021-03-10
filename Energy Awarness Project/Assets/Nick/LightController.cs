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
    public float lightOnVal = 7;

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
            lamp.intensity = lightOnVal;
            GoalManager.current.ChangeCurrentGoalNum(Goal.goalType.LightsOff, -1);
        }
    }
    void OnLightOff(int id)
    {
        if (id == this.id)
        {
            lamp.intensity = lightOffValue;
            GoalManager.current.ChangeCurrentGoalNum(Goal.goalType.LightsOff, 1);
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.onTurnLightOn -= OnLightOn;
        GameEvents.current.onTurnLightOff -= OnLightOff;
    }
}
