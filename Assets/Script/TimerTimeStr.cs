
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class TimerTimeStr : UdonSharpBehaviour
{

    private TextMeshPro text;

    private void Start()
    {
        text = GetComponent<TextMeshPro>();
    }

    public void SetStr(float num)
    {
        int m, s;
        m = (int)num / 60;
        s = (int)num % 60;

        text.text = m.ToString("D2") + " : " + s.ToString("D2");
    }
}
