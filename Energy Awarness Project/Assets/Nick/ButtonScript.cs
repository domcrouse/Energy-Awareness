using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Color idleColor;
    public Color hoverColor;
    public Color selectColor;
    Image image;
    public bool TurnOn;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.color = idleColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        image.color = selectColor;
        if (TurnOn) { InteractiveOptions.Instance.TurnOn(); } else InteractiveOptions.Instance.TurnOff();
        InteractiveOptions.Instance.HideOptions();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = idleColor;
    }
}
