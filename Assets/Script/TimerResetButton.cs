
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TimerResetButton : UdonSharpBehaviour
{
    private Timer timeScript;

    private void Start()
    {
        timeScript = transform.parent.GetComponent<Timer>();
    }

    public override void Interact()
    {
        timeScript.Reset();
    }
}
