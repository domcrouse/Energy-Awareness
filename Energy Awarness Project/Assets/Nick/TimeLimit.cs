using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeLimit : MonoBehaviour
{
    public static TimeLimit current;
    float timer;
    public float maxTime = 300;
    public bool useTimer = true;
    public TMP_Text timerText;
    public Color startColor;
    public Color endColor;

    private void Awake()
    {
        current = this;
        timer = maxTime;
        if (!useTimer) { gameObject.SetActive(false); }
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        timerText.text = timer.ToString("n0");
        timerText.color = Color.Lerp(startColor, endColor, (1 - GetRatio()));
    }

    public int TimeModifiedScore(int score)
    {
        int newScore = Mathf.FloorToInt(score * GetRatio());
        if (useTimer)
        {
            return newScore;
        }
        else { return score; }
    }

    float GetRatio()
    {
        return Mathf.Max(0, (timer/ maxTime));
    }
}
