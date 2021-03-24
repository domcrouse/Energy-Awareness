using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GoalScriptable")]
public class RoomGoalsScriptable : ScriptableObject
{
    public List<Goal> goals;

}

[System.Serializable]
public class Goal
{
    public enum goalType { LightsOff, LightsChange, PostersCollect, EnergyLevel, TempAlter}
    public goalType type;

    public int targetNumber;
    int currentNum;
    public int scoreAward;
    bool hasAchieved = false;

    public int AwardScore()
    {
        if (!hasAchieved) { hasAchieved = true; return TimeLimit.current.TimeModifiedScore(scoreAward); }
        else { return 0; }
    }
    public int GetCurrentNum() { return currentNum; }
    public void AlterCurrentNum(int amountToAdd) { currentNum += amountToAdd; }
    public void ResetCurrent() { currentNum = 0; }
    public void SetAchievedToFalse() { hasAchieved = false; }
}
