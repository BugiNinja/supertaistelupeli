using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    float rndY;
    Vector3 whereToSpawn;
    public float spawnRate = 1f;
    float nextSpawn = 0.0f;

	void Start ()
    {

	}
	
	void Update ()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            rndY = Random.Range(-3.5f, 4f);
            whereToSpawn = new Vector3(transform.position.x, rndY, 0);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
	}
}
