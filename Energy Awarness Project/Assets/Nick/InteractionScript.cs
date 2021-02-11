using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionScript : MonoBehaviour, IPointerClickHandler
{
    public List<GameObject> options;
    public static bool clicked;
    Transform player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerScript>().transform;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        StopAllCoroutines();
        if (Vector3.Magnitude(player.position - transform.position) < 2.5)
        {
            MenuOptions.Show(options);
            for (int i = 0; i < options.Count; i++)
            {
                options[i].SetActive(true);
            }
            clicked = true;
            StartCoroutine(EndActions());
        }
    }

    IEnumerator EndActions()
    {
        yield return new WaitForSeconds(4);
        EndAction();
    }

    void EndAction()
    {
        MenuOptions.Hide(options);
        clicked = false;
    }
}
