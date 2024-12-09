﻿
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Timer : UdonSharpBehaviour
{
    [UdonSynced] private float time;
    [UdonSynced] private bool state;

    [SerializeField] private StateStr statestr;
    [SerializeField] private TimerTimeStr timestr;
    [SerializeField] private TimerErrorStr errorstr;

    AudioSource audioSource;
    [SerializeField] private AudioClip SE;

    private void Start()
    {
        time = 0.0f;
        state = false;
        statestr.SetStr(state);
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (state)
        {
            time -= Time.deltaTime;
            timestr.SetStr(time);

            if (time <= 0.0f)
            {//タイマー終了
                time = 0.0f;
                audioSource.PlayOneShot(SE);
                OnOff();
            }
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("SE再生");
            audioSource.PlayOneShot(SE);
        }
    }

    public void AddTime(float num)
    {
        if (state)
        {
            errorstr.SetAlpha();
            return;
        }

        time += num;
        time = Mathf.Floor(time);
        if (time < 0) time = 0.0f;
        timestr.SetStr(time);
    }

    public void Reset()
    {
        if (state)
        {
            errorstr.SetAlpha();
            return;
        }

        time = 0.0f;
        timestr.SetStr(time);
    }

    public void OnOff()
    {
        state ^= true;
        statestr.SetStr(state);
    }
}