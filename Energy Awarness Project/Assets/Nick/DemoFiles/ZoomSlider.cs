using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomSlider : MonoBehaviour
{
    Slider slider;
    int previous;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        previous = (int)slider.value;        
    }

    public void SetZoom()
    {
        if(slider.maxValue!= CameraControl.Instance.zoomLimit) 
        { slider.maxValue = CameraControl.Instance.zoomLimit; }

        int zoomChange = previous - (int)slider.value;
        if (zoomChange == 0) { return; }
        for (int i = 0; i < (int)Mathf.Abs(zoomChange); i++)
        {
            if (zoomChange < 0)
            {
                GameEvents.current.ZoomIn();
            }
            else GameEvents.current.ZoomOut();
        }
        previous = (int)slider.value;
    }
}
