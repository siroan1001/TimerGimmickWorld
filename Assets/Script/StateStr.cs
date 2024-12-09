using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class StateStr : UdonSharpBehaviour
{
    private TextMeshPro text;

    private void Start()
    {
        text = GetComponent<TextMeshPro>();
    }

    public void SetStr(bool flag)
    {
        if(flag)
        {
            text.text = "Start";
        }
        else
        {
            text.text = "Stop";
        }
    }
}
