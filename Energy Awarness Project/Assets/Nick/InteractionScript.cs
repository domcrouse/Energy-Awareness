using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionScript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public List<GameObject> options;
    public static bool clicked;
    [Range(2,5)]
    public float distanceToInteract = 2.5f;
    Transform player;
    public Material highlightMat;
    Material oldMat;
    MeshRenderer mRenderer;

    private void Awake()
    {
        player = FindObjectOfType<PlayerScript>().transform;
        mRenderer = GetComponent<MeshRenderer>();
        oldMat = mRenderer.material;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        StopAllCoroutines();
        if (Vector3.Magnitude(player.position - transform.position) < distanceToInteract)
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        mRenderer.material = highlightMat;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Renderer>().material = oldMat;
    }
}
