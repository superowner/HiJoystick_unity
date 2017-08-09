//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnValueChange(Vector3 param)
    {
        Debug.Log(param);
    }
}
