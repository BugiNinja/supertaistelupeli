using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHandler : MonoBehaviour {
    //tehnyt Lassi Törmikoski
    public Actions[] actions;
    void Start () {

    }
	void Update () {
        HandleInput();
	}
    void HandleInput()
    {
        for(int i = 0; i < actions.Length; i++)
        {
            if (Input.GetKeyDown(actions[i].GetKey()))
            {
                actions[i].Use();
            } 
        }
    }
}
