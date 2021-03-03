using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TriggerScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public string objectName;
    public int id;
    public int power;
    bool isOn = true;
    public Material highlightMat;
    Material previousMat;
    MeshRenderer mRenderer;

    public void OnPointerClick(PointerEventData eventData)
    {
        InteractiveOptions.Instance.GetTrigger(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mRenderer.material = highlightMat;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mRenderer.material = previousMat;
    }

    // Start is called before the first frame update
    void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
        previousMat = mRenderer.material;
        UIProgressBar.Instance.AddToMax(power);
        if (isOn) { UIProgressBar.Instance.ChangeAmount(power); }
    }
    public bool CheckIfOn() { return isOn; }
    public void SetIsOn(bool setOn) { isOn = setOn; }
}
