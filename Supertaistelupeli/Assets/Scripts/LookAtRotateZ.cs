using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtRotateZ : MonoBehaviour {
    //Rotates on Z Axis
    [Header ("Settings")]
    public bool lookAtMouse;
    [Tooltip ("leave empty if rotates this gameobject")]
    public GameObject rotatingGameObject;
    [Tooltip ("is not needed when looking at mouse")]
    public GameObject targetGameObject;

    [Header ("Flip")]
    [Tooltip ("flip scale Y when looking at behind")]
    public bool flipscale;
    [Tooltip ("flip Y on spriterenderer when looking at behind")]
    public bool flipSprite;

    [Header ("Restrict Rotation")]
    [Tooltip ("Restict directional rotation to angle between 0 to 180, 0 = default, no restriction")]
    public float restrictRotatingAngle = 0;


    Vector3 target;
    public float angleDeg;
    SpriteRenderer sr;

    void Start () {
        restrictRotatingAngle = restrictRotatingAngle / 2;

        if (flipSprite)
        {
            sr = GetComponent<SpriteRenderer>();
        }
        if(targetGameObject != null)
        {
            target = targetGameObject.transform.position;
            
        }
        if (rotatingGameObject == null)
        {
            rotatingGameObject = this.gameObject;
        }
    }

	void Update () {
        //mouseinput
        if (lookAtMouse)
        {
            target = Input.mousePosition;
            target.z = 0;
            target = Camera.main.ScreenToWorldPoint(target);
        }

        // Get angle in radians
        float angleRad = Mathf.Atan2(target.y - rotatingGameObject.transform.position.y, target.x - rotatingGameObject.transform.position.x);
        
        // Get angle in degrees
        angleDeg = (180 / Mathf.PI) * angleRad;

        if ((angleDeg < restrictRotatingAngle && angleDeg > -restrictRotatingAngle) || (angleDeg < -180 + restrictRotatingAngle || angleDeg > 180-restrictRotatingAngle))
        {
            // Rotate object
            rotatingGameObject.transform.rotation = Quaternion.Euler(0, 0, angleDeg);
        }
        
        
        //Flip
        if (angleDeg > 90 || angleDeg < -90)
        {
            if (flipSprite)
            {
                if(sr.flipY == false)
                {
                    sr.flipY = true;

                    //fix rotation if restricting angles
                    if (restrictRotatingAngle != 0)
                    {
                        rotatingGameObject.transform.rotation = Quaternion.Euler(0, 0, angleDeg);
                    }
                }
            }
            if (flipscale)
            {
                if (rotatingGameObject.transform.localScale.y > 0)
                {
                    Vector3 scale = rotatingGameObject.transform.localScale;
                    scale.y = -scale.y;
                    rotatingGameObject.transform.localScale = scale;
                    
                    //fix rotation if restricting angles
                    if (restrictRotatingAngle != 0)
                    {
                        rotatingGameObject.transform.rotation = Quaternion.Euler(0, 0, angleDeg);
                    }
                }
            }
            
        }
        else
        {
            if (flipSprite)
            {
                if (sr.flipY == true)
                {
                    sr.flipY = false;
                }
            }
            if (flipscale)
            {
                if (rotatingGameObject.transform.localScale.y < 0)
                {
                    Vector3 scale = rotatingGameObject.transform.localScale;
                    scale.y = -scale.y;
                    rotatingGameObject.transform.localScale = scale;
                }
            }
        }
    }
}
