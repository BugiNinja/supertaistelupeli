using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Controller : MonoBehaviour {

    bool IsInCombat = false;
    Animator anim;
    private PlayerHealth ph;


    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.T))
        {
            if (IsInCombat == false)
            {
                anim.SetTrigger("SwordSpin");
                anim.SetTrigger("Idle");
            }
            else
            {
                anim.SetTrigger("SwordSpin");
                anim.SetTrigger("CombatIdle");
            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (IsInCombat == false)
            {
                anim.SetTrigger("Taunt");
                anim.SetTrigger("Idle");
            }
            else
            {
                anim.SetTrigger("Taunt");
                anim.SetTrigger("CombatIdle");
            }

        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (IsInCombat == false)
            {
                anim.SetTrigger("IdleTransition");
                anim.SetTrigger("CombatIdle");
                IsInCombat = true;
            }
            else
            {
                anim.SetTrigger("CombatIdleTransition");
                anim.SetTrigger("Idle");
                IsInCombat = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            if (IsInCombat == false)
            {
                anim.SetTrigger("Potion");
                anim.SetTrigger("Idle");
                ph.ApplyHealthRegen(/*3*/);
            }
            else
            {
                anim.SetTrigger("Potion");
                anim.SetTrigger("CombatIdle");
                ph.ApplyHealthRegen(/*3*/);
            }
        }
    }
}
