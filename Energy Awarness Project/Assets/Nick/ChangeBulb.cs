using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBulb : MonoBehaviour, iInteract
{
    public bool needsChanging;
    public bool isLED;
    Light bulb;
    float flickerFrequency;
    float prevIntensity;
    public float flickerIntensity;
    public GameObject tip;
    public string tipText;
    public static int score;

    private void Awake()
    {
        bulb = GetComponent<Light>();
        if (needsChanging)
        {
            prevIntensity = bulb.intensity;
            StartCoroutine("Flicker");
        }
        tip.GetComponentInChildren<TMPro.TMP_Text>().text = tipText;
    }

    public void Interact()
    {
        if (needsChanging) { needsChanging = false; StopCoroutine("Flicker"); score += 5; }
        if (!isLED) { isLED = true; GetComponent<LightController>().SwitchToLED(); tip.SetActive(false); score += 5; }
    }

    IEnumerator Flicker()
    {
        flickerFrequency = Random.Range(0.1f, 2);
        yield return new WaitForSeconds(flickerFrequency);
        if(bulb.intensity == flickerIntensity)
        {
            bulb.intensity = prevIntensity;
        }
        else
        {
            bulb.intensity = flickerIntensity;
        }
        StartCoroutine("Flicker");
    }

}
