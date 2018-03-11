using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Tehnyt Mikko Yrjölä
    float velX = -10f;
    Rigidbody rb;
    public float enemyDamage = 4;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = new Vector3(velX, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
        }
        Destroy(gameObject);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
        Destroy(gameObject);
    }*/
}
