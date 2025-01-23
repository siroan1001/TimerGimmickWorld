
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class StrTest : UdonSharpBehaviour
{
    Text str;

    void Start()
    {
        str = GetComponent<Text>();
    }

    public void debug()
    {
        str.text = "押したよ！";
    }
}
