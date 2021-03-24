﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalManager : MonoBehaviour
{
    [Header("Scriptable Object")]
    public static GoalManager current;
    public RoomGoalsScriptable goals;

    [Header("Notice Board")]
    public Transform GoalTextArea;
    public Color completeGoalColor;
    public Color incompleteGoalColor;
    public TMP_FontAsset font;

    [Header("Score Attributes")]
    public int totalScore;

    [Header("Miscellaneous")]
    public GameObject RedSign;
    public GameObject GreenSign;

    private void Awake()
    {
        current = this;
    }
    private void OnEnable()
    {
        SetGoals();
        GreenSign.SetActive(false);
        LightController.score = 0;
        DeliverPoster.score = 0;
        ChangeBulb.score = 0;
        TempControl.score = 0;
    }

    public bool CheckIfGoalAchieved(int goalNum)
    {
        if (Time.time < 1) { return false; }
        //Check goal current against goal target
        switch (goals.goals[goalNum].type)
        {
            case Goal.goalType.LightsOff:
                if (goals.goals[goalNum].GetCurrentNum() >= goals.goals[goalNum].targetNumber)
                {
                    totalScore += goals.goals[goalNum].AwardScore();
                    return true;
                }
                else return false;
            case Goal.goalType.LightsChange:
                if (goals.goals[goalNum].GetCurrentNum() >= goals.goals[goalNum].targetNumber)
                {
                    totalScore += goals.goals[goalNum].AwardScore();
                    return true;
                }
                else return false;
            case Goal.goalType.PostersCollect:
                if (goals.goals[goalNum].GetCurrentNum() >= goals.goals[goalNum].targetNumber)
                {
                    totalScore += goals.goals[goalNum].AwardScore();
                    return true;
                }
                else return false;
            case Goal.goalType.EnergyLevel:
                if (goals.goals[goalNum].GetCurrentNum() <= goals.goals[goalNum].targetNumber)
                {
                    totalScore += goals.goals[goalNum].AwardScore();
                    return true;
                }
                else return false;
            case Goal.goalType.TempAlter:
                if (goals.goals[goalNum].GetCurrentNum() <= goals.goals[goalNum].targetNumber)
                {
                    totalScore += goals.goals[goalNum].AwardScore();
                    return true;
                }
                else return false;
        }
        return false;
    }

    public void ChangeCurrentGoalNum(int goalNum,int amount)
    {
        goals.goals[goalNum].AlterCurrentNum(amount);
        RefreshGoalList();
    }
    public void ChangeCurrentGoalNum(Goal.goalType type, int amount)
    {
        if (GetGoalNum(type) > -1)
        {
            goals.goals[GetGoalNum(type)].AlterCurrentNum(amount);
            RefreshGoalList();
        }
        else { Debug.Log("Goal doesn't exist"); }
    }
    int GetGoalNum(Goal.goalType type)
    {
        for (int i = 0; i < goals.goals.Count; i++)
        {
            if (goals.goals[i].type == type) { return i; }
        }
        return -1;
    }
    string GetGoalString(int goalNum)
    {
        string goalString = "";
        switch (goals.goals[goalNum].type)
        {
            case Goal.goalType.LightsOff:
                goalString = "Turn off " + goals.goals[goalNum].targetNumber + " lights.";
                break;
            case Goal.goalType.LightsChange:
                goalString = "Change " + goals.goals[goalNum].targetNumber + " flickering lightbulbs.";
                break;
            case Goal.goalType.PostersCollect:
                goalString = "Collect and deliver " + goals.goals[goalNum].targetNumber + " posters.";
                break;
            case Goal.goalType.EnergyLevel:
                goalString = "Reduce the energy consumption to " + goals.goals[goalNum].targetNumber + " kWh.";
                break;
            case Goal.goalType.TempAlter:
                goalString = "Reduce the room temperature to " + goals.goals[goalNum].targetNumber + " degrees.";
                break;
        }
        return goalString;
    }
    void RefreshGoalList()
    {
        int goalsMet = 0;
        for (int i = 0; i < goals.goals.Count; i++)
        {
            if (CheckIfGoalAchieved(i))
            {
                GoalTextArea.GetChild(i).gameObject.GetComponent<TMP_Text>().color = completeGoalColor;
                goalsMet++;
            }
            else
            {
                GoalTextArea.GetChild(i).gameObject.GetComponent<TMP_Text>().color = incompleteGoalColor;
            }
        }
        if (goalsMet == goals.goals.Count && RedSign.activeSelf)
        {//When goals are met the light turns green (on the door or where-ever)
            RedSign.SetActive(false);
            GreenSign.SetActive(true);
            //This calls the unlock door event. Currently has a number should we decide to use id or which door to unlock
            GameEvents.current.UnlockDoor(0);
        }
    }
    
    void SetGoals()
    {
        Debug.Log(goals.goals.Count);
        for (int i = 0; i < goals.goals.Count; i++)
        {//Make new textmesh pros and writes the goals with target numbers
            GameObject goal = new GameObject("GoalText");
            goal.transform.SetParent(GoalTextArea);
            goal.transform.localEulerAngles = Vector3.zero;
            goal.transform.localPosition = Vector3.zero;
            TMP_Text text = goal.AddComponent<TextMeshProUGUI>();
            text.text = GetGoalString(i);
            text.font = font;
            text.fontSize = 0.12f;
            goals.goals[i].SetAchievedToFalse();
            goals.goals[i].ResetCurrent();
        }
        RefreshGoalList();
    }
}
