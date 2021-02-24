using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractiveOptions : MonoBehaviour
{
    public static InteractiveOptions Instance;
    public TMP_Text optionName;
    public TMP_Text optionPower;
    TriggerScript currentTrigger;
    Animator anim;

    private void Awake()
    {
        Instance = this;
        anim = GetComponent<Animator>();
        HideOptions();
    }
    void Setup()
    {
        optionName.text = currentTrigger.objectName;
        optionPower.text = currentTrigger.power.ToString("n0") + "\nKw";
        if (currentTrigger.CheckIfOn()) { optionPower.color = Color.white; }
        else { optionPower.color = Color.black; }
    }

    public void GetTrigger(TriggerScript trigger) 
    {
        if (Time.timeScale == 1)
        {
            currentTrigger = trigger;
            Setup();
        }
    }
    public void ShowOptions()
    {
        anim.SetBool("MoveIn", true);
        Time.timeScale = 0;
    }
    public void HideOptions()
    {
        Time.timeScale = 1;
        anim.SetBool("MoveIn", false);
    }
    public void TurnOn()
    {
        if (!currentTrigger.CheckIfOn())
        {
            GameEvents.current.TurnLightOn(currentTrigger.id);
            UIProgressBar.Instance.ChangeAmount(currentTrigger.power);
            currentTrigger.SetIsOn(true);
            Setup();
        }
    }
    public void TurnOff()
    {
        if (currentTrigger.CheckIfOn())
        {
            GameEvents.current.TurnLightOff(currentTrigger.id);
            UIProgressBar.Instance.ChangeAmount(-currentTrigger.power);
            currentTrigger.SetIsOn(false);
            Setup();
        }
    }
}
