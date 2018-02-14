using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float inputDirection;
    private float verticalVelocity;

    private float gravity = 30.0f;
    private float jumpForce = 10.0f;
    private bool secondJumpAvail = false;
    public bool doubleWallJump = false;

    private Vector3 moveVector;
    private Vector3 lastMotion;
    private CharacterController controller;

    private float moveSpeed;
    private float walkSpeed = 3f;
    private float runSpeed = 5f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Running
        if (Input.GetKey(KeyCode.R))
        {
            moveSpeed = runSpeed;
        }

        //Walking
        else
        {
            moveSpeed = walkSpeed;
        }

        moveVector = Vector3.zero;
        inputDirection = Input.GetAxis("Horizontal") * moveSpeed;

        if (IsControllerGrounded())
        {
            verticalVelocity = 0;

            if (Input.GetKeyDown(KeyCode.W))
            {
                verticalVelocity = jumpForce;
                secondJumpAvail = true;
            }

            moveVector.x = inputDirection;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if(secondJumpAvail)
                {
                    verticalVelocity = jumpForce;
                    secondJumpAvail = false;
                }
            }

            verticalVelocity -= gravity * Time.deltaTime;
            moveVector.x = lastMotion.x;
        }

        moveVector.y = verticalVelocity;
        controller.Move(moveVector * Time.deltaTime);
        lastMotion = moveVector;
    }

    private bool IsControllerGrounded()
    {
        Vector3 leftRayStart;
        Vector3 rightRayStart;

        leftRayStart = controller.bounds.center;
        rightRayStart = controller.bounds.center;

        leftRayStart.x -= controller.bounds.extents.x;
        rightRayStart.x += controller.bounds.extents.x;

        Debug.DrawRay(leftRayStart, Vector3.down, Color.red);
        Debug.DrawRay(rightRayStart, Vector3.down, Color.green);
        RaycastHit hit;
        if(Physics.Raycast(leftRayStart, Vector3.down, out hit, (controller.height / 2) + 0.2f))
        {
            if (hit.collider.gameObject.tag.Equals("Ground"))
            {
                return true;
            }
            
        }
        if (Physics.Raycast(rightRayStart, Vector3.down, out hit, (controller.height / 2) + 0.2f))
        {
            if (hit.collider.gameObject.tag.Equals("Ground"))
            {
                return true;
            }
        }

        return false;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(controller.collisionFlags == CollisionFlags.Sides)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                Debug.DrawRay(hit.point, hit.normal, Color.red, 2.0f);
                moveVector = hit.normal * moveSpeed;
                verticalVelocity = jumpForce;
                secondJumpAvail = doubleWallJump;
            }
        }
    }
}
