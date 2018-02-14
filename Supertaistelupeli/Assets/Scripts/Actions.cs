using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actions : MonoBehaviour {
    public abstract void Use();
    public abstract KeyCode GetKey();
}
