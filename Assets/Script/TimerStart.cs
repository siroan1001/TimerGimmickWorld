
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TimerStart : UdonSharpBehaviour
{
    //[SerializeField] private TMPro.TMP_Text text;
    //[SerializeField] private TextMeshPro text;

    public override void Interact()
    {
        transform.parent.GetComponent<Timer>().OnOff();
    }
}
