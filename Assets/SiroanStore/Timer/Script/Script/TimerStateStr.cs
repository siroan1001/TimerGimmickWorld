
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class TimerStateStr : UdonSharpBehaviour
{
    [SerializeField] private TextMeshPro text;

    public void SetStr(bool flag)
    {
        string str = "error";
        if (flag)
        {
            str = "Start";
        }
        else
        {
            str = "Stop";
        }
        text.text = str;
    }
}
