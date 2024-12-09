﻿
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class TimerErrorStr : UdonSharpBehaviour
{
    private TextMeshPro text;

    private void Start()
    {
        text = GetComponent<TextMeshPro>();
    }

    void FixedUpdate()
    {
        Color col = text.color;
        float num = text.color.a;
        if (text.color.a > 0.0f)
        {
            num -= 0.015f;
            if (num < 0.0f) num = 0.0f;
            col.a = num;
            text.color = col;
        }
    }

    public void SetAlpha()
    {
        Color col = text.color;
        col.a = 1.0f;
        text.color = col;
    }
}
