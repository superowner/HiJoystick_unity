//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example5 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        var test = GameObject.FindObjectOfType<ScrollCircle5>();
        test.startDrag = StartDrag;
        test.dragging = Dragging;
        test.endDrag = EndDrag;


    }

    void StartDrag()
    {
        Debug.Log("start drag");
    }

    void Dragging(Vector3 param)
    {
        Debug.Log(param);
    }

    void EndDrag()
    {
        Debug.Log("end drag");
    }



// Update is called once per frame
    void Update()
    {

    }
}
