
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TimerStart : UdonSharpBehaviour
{

    public override void Interact()
    {
        transform.parent.GetComponent<Timer>().OnOff();
    }
}
