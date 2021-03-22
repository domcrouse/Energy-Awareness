using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverPoster : MonoBehaviour, iInteract
{
    int posterNum = 0;
    public GameObject tip;
    public string tipText;
    public static int score;
    private void Start()
    {
        GameEvents.current.onPickUpPoster += AddPoster;
        tip.GetComponentInChildren<TMPro.TMP_Text>().text = tipText;
    }
    private void Update()
    {
        if (posterNum > 0) { tip.SetActive(true); }
        else { tip.SetActive(false); }
    }
    private void OnDisable()
    {
        GameEvents.current.onPickUpPoster -= AddPoster;
    }
    public void Interact()
    {
        GameEvents.current.DeliverPoster(posterNum);
        score += (posterNum * 5);
        posterNum = 0;
    }

    void AddPoster()
    {
        posterNum++;
    }
}
