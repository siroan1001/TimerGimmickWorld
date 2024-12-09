
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TimerCounter : UdonSharpBehaviour
{
    [SerializeField] private float time = 0;
    private Timer timeScript;

    private void Start()
    {
        timeScript = transform.parent.GetComponent<Timer>();
    }

    public override void Interact()
    {
        timeScript.AddTime(time);
    }
}
