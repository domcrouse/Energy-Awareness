﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TempControl : MonoBehaviour
{
    public TMP_Text tempText;
    public int energyPerPoint = 5;
    public int zeroEnergyPoint = 10;
    public int temp = 25;
    public int maxTemp = 40;
    public int minTemp = -20;

    public GameObject tip;
    public string tipText;
    public static int score;
    private void Start()
    {
        GameEvents.current.onChangeTemp += ChangeTemp;
        GoalManager.current.ChangeCurrentGoalNum(Goal.goalType.EnergyLevel, Energy(temp-zeroEnergyPoint));
        GoalManager.current.ChangeCurrentGoalNum(Goal.goalType.TempAlter, temp);
        UIProgressBar.Instance.ChangeAmount(Energy(temp-zeroEnergyPoint));
        UIProgressBar.Instance.AddToMax(Energy(maxTemp));
        tip.GetComponentInChildren<TMP_Text>().text = tipText;
    }
    private void OnDisable()
    {
        GameEvents.current.onChangeTemp -= ChangeTemp;
    }
    void ChangeTemp(int amount)
    {
        if ((temp < maxTemp && amount>0)|| (temp > minTemp && amount <0))
        {
            temp += amount;
            if (temp < zeroEnergyPoint) { amount *= -1; }
            if (temp == zeroEnergyPoint && amount > 0) { amount *= -1; }
            GoalManager.current.ChangeCurrentGoalNum(Goal.goalType.TempAlter, amount);
            UpdateTemp();
            GoalManager.current.ChangeCurrentGoalNum(Goal.goalType.EnergyLevel, Energy(amount));
            UIProgressBar.Instance.ChangeAmount(Energy(amount));
            score -= amount * TimeLimit.current.TimeModifiedScore(5);
        }
        else
        {
            //Currently does nothing. Could have sound effect or something else
        }
    }
    void UpdateTemp() { tempText.text = temp.ToString("n0"); }
    int Energy(int amount) { return (amount * energyPerPoint); }
}
