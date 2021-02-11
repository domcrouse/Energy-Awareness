using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionScript : MonoBehaviour, IPointerClickHandler
{
    public List<GameObject> options;
    public static bool clicked;
    public void OnPointerClick(PointerEventData eventData)
    {
        MenuOptions.Show(options);
        for (int i = 0; i < options.Count; i++)
        {
            options[i].SetActive(true);
        }
        clicked = true;
        Invoke("EndAction", 4);
    }

    void EndAction()
    {
        MenuOptions.Hide(options);
        clicked = false;
    }
}
