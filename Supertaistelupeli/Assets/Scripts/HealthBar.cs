using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    GameObject player;
    private PlayerHealth ph;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            ph = player.GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        transform.localScale = new Vector3(ph.GetHealth() / 20, 1f, 1f);       
    }
}
