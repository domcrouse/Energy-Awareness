using System.Collections;
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

    [Header("Score Attributes")]
    public int totalScore;

    [Header("Miscellaneous")]
    public int roomTemp = 25;

    private void Awake()
    {
        current = this;
        SetGoals();
    }

    public bool CheckIfGoalAchieved(int goalNum)
    {
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
        goals.goals[GetGoalNum(type)].AlterCurrentNum(amount);
        RefreshGoalList();
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
        for (int i = 0; i < goals.goals.Count; i++)
        {
            if (CheckIfGoalAchieved(i))
            {
                GoalTextArea.GetChild(i).gameObject.GetComponent<TMP_Text>().color = completeGoalColor;
            }
            else
            {
                GoalTextArea.GetChild(i).gameObject.GetComponent<TMP_Text>().color = incompleteGoalColor;
            }
        }
    }
    
    void SetGoals()
    {
        for (int i = 0; i < goals.goals.Count; i++)
        {//Make new textmesh pros and writes the goals with target numbers
            GameObject goal = new GameObject();
            goal.AddComponent<TMP_Text>();
            goal.GetComponent<TMP_Text>().text = GetGoalString(i);
            goal.transform.SetParent(GoalTextArea);
            if (goals.goals[i].type == Goal.goalType.TempAlter) { ChangeCurrentGoalNum(i, roomTemp); }
        }
    }
}
