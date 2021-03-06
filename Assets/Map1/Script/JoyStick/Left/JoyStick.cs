using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour
{


    Animator ani;
    // Use this for initialization
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Drag(BaseEventData _Data)
    {

        ani.SetBool("isRun", true);
        ani.Play("run");
    }

    public void DragEnd()
    {
        ani.SetBool("isRun", false);
    }


}
