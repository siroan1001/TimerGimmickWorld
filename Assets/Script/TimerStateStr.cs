
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class TimerStateStr : UdonSharpBehaviour
{
    private TextMeshPro text;

    void Start()
    {
        text = GetComponent<TextMeshPro>();
    }

    public void SetStr(bool flag)
    {
        //Debug.Log("State文字更新" + Networking.LocalPlayer.playerId);
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
