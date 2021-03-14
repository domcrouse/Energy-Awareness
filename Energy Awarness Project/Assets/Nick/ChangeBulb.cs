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

    private void Awake()
    {
        bulb = GetComponent<Light>();
        if (needsChanging)
        {
            prevIntensity = bulb.intensity;
            StartCoroutine("Flicker");
        }
    }

    public void Interact()
    {
        if (needsChanging) { needsChanging = false; StopCoroutine("Flicker"); }
        if (!isLED) { isLED = true; GetComponent<LightController>().SwitchToLED();}
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
