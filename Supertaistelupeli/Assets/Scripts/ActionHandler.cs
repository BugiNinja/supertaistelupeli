using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHandler : MonoBehaviour {
    public bool canMove = false;
    public bool canJump = false;
    public bool canAttack = false;
    public bool canRun = false;
    public Actions[] actions;
    void Start () {
        if(canMove)
            gameObject.AddComponent<Movement>();
        if(canJump)
            gameObject.AddComponent<Jump>();
        if(canAttack)
            gameObject.AddComponent<Attack>();
        if(canRun)
            gameObject.AddComponent<Run>();
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
