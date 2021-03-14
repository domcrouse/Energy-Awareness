using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHighlight : MonoBehaviour
{
    public Material highlightMat;
    bool isHighlight = false;
    Material[] prevMats;
    Material[] highlights;
    MeshRenderer mesh;

    private void OnBecameVisible()
    {
        StartCoroutine("Highlight");
    }

    private void OnBecameInvisible()
    {
        StopCoroutine("Highlight");
    }

    private void OnEnable()
    {
        mesh = GetComponent<MeshRenderer>();
        prevMats = mesh.materials;
        highlights = new Material[prevMats.Length];
        for (int i = 0; i < highlights.Length; i++)
        {
            highlights[i] = highlightMat;
        }
    }

    IEnumerator Highlight()
    {
        isHighlight = !isHighlight;
        yield return new WaitForSeconds(1.5f);
        if (isHighlight) 
        {
            mesh.materials = prevMats;
        }
        else 
        {
            mesh.materials = highlights;
        }
        StartCoroutine("Highlight");
    }
}
