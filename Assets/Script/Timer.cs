
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using System;

public class Timer : UdonSharpBehaviour
{
    [UdonSynced] private float time;
    [UdonSynced] private bool state;

    [SerializeField] private TimerStateStr statestr;
    [SerializeField] private Transform timestr;
    [SerializeField] private TimerErrorStr errorstr;

    AudioSource audioSource;
    [SerializeField] private AudioClip SE;
    [SerializeField] private bool MuteFlag;

    private void Start()
    {
        time = 0.0f;
        state = false;
        statestr.SetStr(state);
        audioSource = GetComponent<AudioSource>();
        MuteFlag = false;
    }

    private void Update()
    {
        if (state)
        {
            time -= Time.deltaTime;
            if (time <= 0.0f)
            {//タイマー終了
                time = 0.0f;
                if(!MuteFlag) audioSource.PlayOneShot(SE);
                state = false;
            }

            RequestSerialization();
        }

        statestr.SetStr(state);
        for (int i = 0; i < timestr.childCount; i++)
        {
            timestr.GetChild(i).GetComponent<TimerTimeStr>().SetStr(time);
        }
    }

    public void AddTime(float num)
    {
        if (state)
        {
            errorstr.SetAlpha();
            return;
        }

        if (!Networking.IsOwner(Networking.LocalPlayer, this.gameObject))
        {
            SetAllObjOwner();
        }

        time += num;
        time = Mathf.Floor(time);
        if (time < 0) time = 0.0f;
        RequestSerialization();
    }

    public void Reset()
    {
        if (state)
        {
            errorstr.SetAlpha();
            return;
        }

        if (!Networking.IsOwner(Networking.LocalPlayer, this.gameObject))
        {
            SetAllObjOwner();
        }

        time = 0.0f;
        RequestSerialization();
    }

    public void OnOff()
    {
        if (time <= 0.0f) return;

        if (!Networking.IsOwner(Networking.LocalPlayer, this.gameObject))
        {
            SetAllObjOwner();
        }

        state ^= true;
        RequestSerialization();
    }

    public bool Mute()
    {
        if (!Networking.IsOwner(Networking.LocalPlayer, this.gameObject))
        {
            SetAllObjOwner();
        }

        MuteFlag ^= true;
        RequestSerialization();

        return MuteFlag;
    }

    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        RequestSerialization();
    }

    private void SetAllObjOwner()
    {
        Transform parent = this.transform;
        while (parent.parent != null)
        {
            parent = parent.parent;
        }

        Networking.SetOwner(Networking.LocalPlayer, parent.gameObject);

        var parentAndChildren = parent.GetComponentsInChildren<Transform>(true);

        var children = new Transform[parentAndChildren.Length - 1];
        Array.Copy(parentAndChildren, 1, children, 0, children.Length);
        for (int i = 0; i < children.Length; i++)
        {
            Networking.SetOwner(Networking.LocalPlayer, children[i].gameObject);
        }
    }
}
