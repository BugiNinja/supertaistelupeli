using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : Actions
{
    KeyCode Key = KeyCode.LeftShift;
    bool isDone = false;
    float runMultiplier = 0.5f;
    public bool toggleRun = true;
    Movement move;

    void Start()
    {
        move = GetComponent<Movement>();
    }

    public override KeyCode GetKey()
    {
        return Key;
    }

    public override void Use()
    {

        if (!isDone)
        {
           // move.speedMultiplier += runMultiplier;
            isDone = true;
        }
        else
        {
            //move.speedMultiplier -= runMultiplier;
            isDone = false;
        }
        
        
    }
}

