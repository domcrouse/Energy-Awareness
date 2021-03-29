using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class HighScores : MonoBehaviour
{
    const string privateCode = "MllVoL8LfE2eE9cbmFgyEAmyY1NmnUPka7d95DmvBkPA";
    const string publicCode = "605947318f40bb473466f256";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoresList;
    public TMP_Text highscoreDisplayTxt;
    public TMP_InputField inputField;
    public static HighScores current;

    bool gotScores = false;

    private void Awake()
    {
        current = this;
    }

    private void Update()
    {
        if (gotScores)
        {
            if (highscoresList == null) { highscoreDisplayTxt.text = "loading..."; }
            else { gotScores = false; }
        }
    }

    public void AddNewHighscore(string username,int score)
    {
        StartCoroutine(UploadNewHighscore(username, score));
    }
    IEnumerator UploadNewHighscore(string username,int score)
    {
        UnityWebRequest www = UnityWebRequest.Get(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
        yield return www.SendWebRequest();

        if (string.IsNullOrEmpty(www.error))
        {
            gotScores = true;
            Debug.Log(www.result);
            DownloadHighscores();
        }
        else { Debug.Log("Error uploading: " + www.error); }
    }
    public void DownloadHighscores()
    {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }
    IEnumerator DownloadHighscoresFromDatabase()
    {
        UnityWebRequest www = UnityWebRequest.Get(webURL + publicCode + "/pipe/");
        yield return www.SendWebRequest();

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.downloadHandler.text);
        }
        else { Debug.Log("Error uploading: " + www.error); }
    }
    public void DisplayHighScores()
    {
        highscoreDisplayTxt.text = "";
        for (int i = 0; i < highscoresList.Length; i++)
        {
            highscoreDisplayTxt.text += highscoresList[i].username + ": " + highscoresList[i].score + "<size=10>pts</size>\n";
        }
        if (highscoresList.Length == 0) { highscoreDisplayTxt.text = "Currently there are no highscores."; }
    }
    public void SubmitScore()
    {
        AddNewHighscore(inputField.text, ScoreCard.current.GetFinalScore());
    }

    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];
        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
        }
        DisplayHighScores();
    }
}

public struct Highscore
{
    public string username;
    public int score;

    public Highscore(string _username,int _score)
    {
        username = _username;
        score = _score;
    }
}