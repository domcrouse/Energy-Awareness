using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
//Tutorial used: https://www.youtube.com/watch?v=J1ng1zA3-Pk
[ExecuteInEditMode()]
public class UIProgressBar : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("GameObject/UI/Linear Progress Bar")]
    public static void AddLinearProgressBar()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("UI/LinearProgressBar"));
        obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }
    [MenuItem("GameObject/UI/Radial Progress Bar")]
    public static void AddRadialProgressBar()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("UI/RadialProgressBar"));
        obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }
#endif

    public int minimum;
    public int maximum;
    public int current;

    public Image mask;//This will be filled to the current amount
    public Image fill;
    public Color color;
    public TMPro.TMP_Text value;

    public static UIProgressBar Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        GetCurrentFill();
        value.text = current + " kWh";
    }
    void GetCurrentFill()
    {
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;

        fill.color = color;
    }
    public void AddToMax(int value) { maximum += value; }

    public void ChangeAmount(int changeInValue) { current += changeInValue; }
}
