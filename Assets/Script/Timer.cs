
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Timer : UdonSharpBehaviour
{
    [UdonSynced] private float time;
    [UdonSynced] private bool state;

    [SerializeField] private TimerStateStr statestr;
    [SerializeField] private Transform timestr;
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
            RequestSerialization();
            for (int i = 0; i < transform.childCount; i++)
            {
                timestr.GetComponent<TimerTimeStr>().SetStr(time);
            }
            if (time <= 0.0f)
            {//タイマー終了
                time = 0.0f;
                RequestSerialization();
                audioSource.PlayOneShot(SE);
                OnOff();
            }
        }

        //if(Input.GetKeyDown(KeyCode.P))
        //{
        //    Debug.Log("SE再生");
        //    audioSource.PlayOneShot(SE);
        //}
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
        RequestSerialization();
        if (time < 0) time = 0.0f; 
        for (int i = 0; i < transform.childCount; i++)
        {
            timestr.GetChild(i).GetComponent<TimerTimeStr>().SetStr(time);
        }
    }

    public void Reset()
    {
        if (state)
        {
            errorstr.SetAlpha();
            return;
        }

        time = 0.0f;
        RequestSerialization();
        for (int i = 0; i < transform.childCount; i++)
        {
            timestr.GetChild(i).GetComponent<TimerTimeStr>().SetStr(time);
        }
    }

    public void OnOff()
    {
        state ^= true;
        RequestSerialization();
        statestr.SetStr(state);
    }
}
