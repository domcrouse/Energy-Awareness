using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapAtRandom : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    Vector3 pos1;
    Vector3 pos2;

    private void OnEnable()
    {
        pos1 = button1.transform.position;
        pos2 = button2.transform.position;
    }

    public void Swap()
    {
        int num = Random.Range(0, 2);
        switch (num)
        {
            case 0:button1.transform.position = pos1;button2.transform.position = pos2;break;
            case 1:button1.transform.position = pos2;button2.transform.position = pos1;break;
        }
    }
}
