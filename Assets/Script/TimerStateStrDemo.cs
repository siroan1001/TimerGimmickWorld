
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class TimerStateStrDemo : UdonSharpBehaviour
{
    [SerializeField] private Timer script;

    /*[UdonSynced] */private Text text;
    private bool Flag;

    void Start()
    {
        text = GetComponent<Text>();

        Flag = script.State;
        UpdateText();
    }

    private void Update()
    {
        Debug.Log("ステート文字の更新");
        bool foge = script.State;
        if (foge != Flag)
        {
            Flag = script.State;
            UpdateText();
        }
    }

    private void UpdateText()
    {
        if (Flag)   text.text = "On";
        else        text.text = "Off";

        //RequestSerialization();
    }
}
