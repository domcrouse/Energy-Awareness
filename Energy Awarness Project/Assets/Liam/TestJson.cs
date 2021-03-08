using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TestJson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("https://www.dropbox.com/s/mpmglw6ke8x5sir/questions.json?dl=1"));
    }

    // Update is called once per frame
    void Update()
    {

    }
    public string textToParse;
    Questions questions;
    public Text questionTxtBox;
    public Text answerTxtBox1;
    public Text answerTxtBox2;
    public Text answerTxtBox3;

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log("Error404");
            }
            else
            {
                Debug.Log(pages[page] + "text of page is" + webRequest.downloadHandler.text);
                textToParse = webRequest.downloadHandler.text;
                questions = JsonUtility.FromJson<Questions>(textToParse);
                questionTxtBox.text = questions.questions[0];
                answerTxtBox1.text = questions.answers[0];
                answerTxtBox2.text = questions.answers[1];
                answerTxtBox3.text = questions.answers[2];
            }
        }
    }
}