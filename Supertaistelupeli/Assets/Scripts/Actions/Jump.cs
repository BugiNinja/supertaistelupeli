using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Actions
{
    Rigidbody rb;
    KeyCode Key = KeyCode.W;
    public float jumpVelocity = 4.0f;
    int jumpCount = 0;
    public int maxJumpCount = 2;
    public bool isDone = false;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public override KeyCode GetKey()
    {
        return Key;
    }

    public override void Use()
    {
        if (jumpCount < maxJumpCount && !isDone)
        {
            rb.velocity = Vector3.up * jumpVelocity;
            jumpCount++;
        }
        isDone = true;
    }
    private void Update()
    {
        if(isDone && !Input.GetKey(Key))
        {
            isDone = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            jumpCount = 0;
        }
    }
}
