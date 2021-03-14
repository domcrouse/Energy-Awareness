using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class UIPosters : MonoBehaviour
{
    int posters = 0;
    TMP_Text text;
    private void OnEnable()
    {
        GameEvents.current.onPickUpPoster += AddPoster;
        GameEvents.current.onDeliverPoster += Delivery;
        text = GetComponent<TMP_Text>();
    }
    private void OnDisable()
    {
        GameEvents.current.onPickUpPoster -= AddPoster;
        GameEvents.current.onDeliverPoster -= Delivery;
    }
    void AddPoster() { posters++; UpdateText(); }
    void Delivery(int amount) 
    { 
        posters = 0;
        UpdateText();
        GoalManager.current.ChangeCurrentGoalNum(Goal.goalType.PostersCollect, amount);
    }
    void UpdateText() { text.text = "Posters: " + posters; }
}
