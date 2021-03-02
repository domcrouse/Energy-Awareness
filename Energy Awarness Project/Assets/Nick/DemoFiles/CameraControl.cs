using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Vector3 initialPos;
    public static CameraControl Instance;
    Transform focus;
    Vector3 focusPos;
    int magnificationLevel;
    public int zoomLimit;

    void Start()
    {
        Instance = this;
        initialPos = transform.position;
        GameEvents.current.onZoomIn += ZoomIn;
        GameEvents.current.onZoomOut += ZoomOut;
    }

    private void OnDestroy()
    {
        GameEvents.current.onZoomIn -= ZoomIn;
        GameEvents.current.onZoomOut -= ZoomOut;
    }

    public void FocusOn(Transform focusObject) { focus = focusObject; focusPos = focus.position; }

    public void ZoomIn()
    {
        if (magnificationLevel < zoomLimit)
        {
            magnificationLevel++;
            transform.position -= CalculateVector();
        }
    }
    public void ZoomOut()
    {
        if (magnificationLevel > 0)
        {
            magnificationLevel--;
            transform.position += CalculateVector();
            if (magnificationLevel == 0) { focusPos = focus.position; }
        }
    }

    Vector3 CalculateVector()
    {
        Vector3 vector = (initialPos - focusPos).normalized;

        return vector;
    }
}
