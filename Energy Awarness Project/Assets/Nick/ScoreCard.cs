using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCard : MonoBehaviour
{
    [Header("Panels")]
    public GameObject quizScreen;
    public GameObject scoreCard;
    public GameObject leaveRoomDecision;

    [Header("Text")]
    public TMP_Text lightsOffScore;
    public TMP_Text postersDeliveredScore;
    public TMP_Text bulbsChangedScore;
    public TMP_Text temperatureScore;
    public TMP_Text goalsAchievedScore;
    public TMP_Text quizResultScore;
    public TMP_Text totalScore;

    [Header("Buttons")]
    public GameObject leaveButton;
    public GameObject highscoreButton;

    MovementController player1;
    MouseHandler player2;
    public static ScoreCard current;
    int score;

    float numberFreq = 0.05f;
    int counter = 0;
    public enum scoreType { LightsOff,Posters,Bulbs,Temp,Goals,Quiz,Final}
    scoreType type = scoreType.LightsOff;

    private void Awake()
    {
        player1 = FindObjectOfType<MovementController>();
        player2 = FindObjectOfType<MouseHandler>();
        current = this;
    }

    public void ShowDecision() { leaveRoomDecision.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        player1.enabled = false;player2.enabled = false;
    }
    public void HideDecision() { leaveRoomDecision.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player1.enabled = true; player2.enabled = true;
    }
    public void ShowQuiz()
    {
        Time.timeScale = 0;
        quizScreen.SetActive(true);
    }
    public void ShowScore()
    {
        scoreCard.SetActive(true);
        StartCoroutine("ShowScoreNumber");
    }

    public int GetFinalScore()
    {
        return (LightController.score + DeliverPoster.score + ChangeBulb.score + TempControl.score + GoalManager.current.totalScore + score);
    }

    IEnumerator ShowScoreNumber()
    {
        yield return new WaitForSecondsRealtime(numberFreq);
        counter++;
        switch (type)
        {
            case scoreType.LightsOff:
                lightsOffScore.text = counter.ToString("n0");
                if (counter == LightController.score) { type = scoreType.Posters; counter = -1; }
                break;
            case scoreType.Posters:
                postersDeliveredScore.text = counter.ToString("n0");
                if (counter == DeliverPoster.score) { type = scoreType.Bulbs; counter = -1; }
                break;
            case scoreType.Bulbs:
                bulbsChangedScore.text = counter.ToString("n0");
                if (counter == ChangeBulb.score) { type = scoreType.Temp; counter = -1; }
                break;
            case scoreType.Temp:
                temperatureScore.text = counter.ToString("n0");
                if (counter == TempControl.score) { type = scoreType.Goals; counter = -1; }
                break;
            case scoreType.Goals:
                goalsAchievedScore.text = counter.ToString("n0");
                if (counter == GoalManager.current.totalScore) { type = scoreType.Quiz; counter = -1; }
                break;
            case scoreType.Quiz:
                quizResultScore.text = counter.ToString("n0");
                if (counter == score) { type = scoreType.Final; counter = -1; }
                break;
            case scoreType.Final:
                totalScore.text = counter.ToString("n0");
                if(counter== (LightController.score+ DeliverPoster.score+ ChangeBulb.score+ TempControl.score+ GoalManager.current.totalScore + score)) { leaveButton.SetActive(true); highscoreButton.SetActive(true); StopCoroutine("ShowScoreNumber"); yield break; }
                break;
        }
        StartCoroutine("ShowScoreNumber");
    }
    void AnswerScore() { score += TimeLimit.current.TimeModifiedScore(30); }

    private void Start()
    {
        GameEvents.current.onLeaveRoom += ShowDecision;
        GameEvents.current.onCorrectAnswer += AnswerScore;
    }
    private void OnDestroy()
    {
        GameEvents.current.onLeaveRoom -= ShowDecision;
        GameEvents.current.onCorrectAnswer -= AnswerScore;
    }
}
