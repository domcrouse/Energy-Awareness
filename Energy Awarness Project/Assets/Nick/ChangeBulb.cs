using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBulb : MonoBehaviour, iInteract
{
    public bool needsChanging;
    public bool isLED;
    Light bulb;
    public float flickerFrequency;
    float prevIntensity;
    public float flickerIntensity;

    private void Awake()
    {
        bulb = GetComponent<Light>();
        if (needsChanging)
        {
            prevIntensity = bulb.intensity;
            Invoke("Flicker",0);
        }
    }

    public void Interact()
    {
        if (needsChanging) { needsChanging = false; StopCoroutine("Flicker"); }
        if (!isLED) { isLED = true; }
    }

    IEnumerator Flicker()
    {
        yield return new WaitForSeconds(flickerFrequency);
        if(bulb.intensity == flickerIntensity)
        {
            bulb.intensity = prevIntensity;
        }
        else
        {
            bulb.intensity = flickerIntensity;
        }
        Invoke("Flicker",0);
    }
}
