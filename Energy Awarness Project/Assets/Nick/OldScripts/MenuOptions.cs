using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour
{
    GameObject firstOption;
    

    static MenuOptions instance;

    private void Awake()
    {
        instance = this;
        firstOption = transform.GetChild(0).gameObject;
        gameObject.SetActive(false);
    }

    public static void Show(List<GameObject> optionsToShow)
    {
        instance.gameObject.SetActive(true);
        instance.firstOption.SetActive(true);
        for (int i = 0; i < optionsToShow.Count; i++)
        {
            optionsToShow[i].SetActive(true);
        }
    }

    public static void Hide(List<GameObject> optionsToShow)
    {
        for (int i = 0; i < optionsToShow.Count; i++)
        {
            optionsToShow[i].SetActive(false);
        }
        instance.gameObject.SetActive(false);
    }

    public void EndAction()
    {
        List<GameObject> children = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            children.Add(transform.GetChild(i).gameObject);
        }
        InteractionScript.clicked = false;
        Hide(children);
    }
}
