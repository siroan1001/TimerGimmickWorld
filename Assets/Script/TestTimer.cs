
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TestTimer : UdonSharpBehaviour
{
    [SerializeField] StrTest script;

    void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            script.debug();
        }
    }
}
