
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TimerPresetButton : UdonSharpBehaviour
{
    [SerializeField] private float Seconds;
    private Timer timeScript;

    private void Start()
    {
        timeScript = transform.parent.GetComponent<Timer>();
    }

    public override void Interact()
    {
        timeScript.Reset();
        timeScript.AddTime(Seconds);
    }
}
