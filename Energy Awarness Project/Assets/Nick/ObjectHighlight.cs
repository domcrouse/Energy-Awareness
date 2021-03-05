using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHighlight : MonoBehaviour
{
    public Material highlightMat;
    Material prevMat;
    MeshRenderer mesh;

    private void OnEnable()
    {
        mesh = GetComponent<MeshRenderer>();
        prevMat = mesh.material;
        Highlight();
    }

    public void Highlight()
    {
        StopCoroutine(LightUp());
        mesh.material = highlightMat;
        StartCoroutine(LightUp());
    }

    IEnumerator LightUp()
    {
        yield return new WaitForSeconds(5);
        mesh.material = prevMat;
    }
}
