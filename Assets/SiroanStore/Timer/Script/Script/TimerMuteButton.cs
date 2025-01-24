
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TimerMuteButton : UdonSharpBehaviour
{
    private Timer timeScript;
    private Color DefColor;
    [UdonSynced] bool flag;

    void Start()
    {
        timeScript = transform.parent.GetComponent<Timer>();
        DefColor = GetComponent<Renderer>().material.color;
        flag = false;
        RequestSerialization();
    }

    public override void Interact()
    {
        flag = timeScript.Mute();
        RequestSerialization();
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, nameof(ChangeColor));
    }

    public void ChangeColor()
    {
        Color color = DefColor;
        if (flag)
        {
            color = new Color(255.0f, 0.0f, 0.0f, 1.0f);
        }
        GetComponent<Renderer>().material.color = color;
    }

    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        RequestSerialization();
        ChangeColor();
    }
}
