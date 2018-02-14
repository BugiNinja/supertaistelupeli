using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Actions {
    KeyCode Key = KeyCode.A;
    bool isDone = false;

    public override KeyCode GetKey()
    {
        return Key;
    }

    public override void Use()
    {
        Debug.Log("attack");
        isDone = true;
    }
}
