using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject EnemyShipA;
    public GameObject EnemyShipB;

    private int enemies = 0;
    bool AorB = true;

    private void Start()
    {

    }

    private void Update()
    {
        if (enemies <= 0)
        {
            SpawnWave();
        }
    }

    void SpawnWave () 
    {
        if (AorB) 
        {
            Instantiate(EnemyShipA, new Vector3(-8, 23, 0), EnemyShipA.transform.rotation);
            Instantiate(EnemyShipA, new Vector3(-4, 21, 0), EnemyShipA.transform.rotation);
            Instantiate(EnemyShipA, new Vector3(0, 19, 0), EnemyShipA.transform.rotation);
            Instantiate(EnemyShipA, new Vector3(4, 21, 0), EnemyShipA.transform.rotation);
            Instantiate(EnemyShipA, new Vector3(8, 23, 0), EnemyShipA.transform.rotation);
            enemies = 5;
            AorB = false;
        }
        else 
        {
            Instantiate(EnemyShipB, new Vector3(-8, 19, 0), EnemyShipA.transform.rotation);
            Instantiate(EnemyShipB, new Vector3(-4, 21, 0), EnemyShipA.transform.rotation);
            Instantiate(EnemyShipB, new Vector3(0, 23, 0), EnemyShipA.transform.rotation);
            Instantiate(EnemyShipB, new Vector3(4, 25, 0), EnemyShipA.transform.rotation);
            Instantiate(EnemyShipB, new Vector3(8, 27, 0), EnemyShipA.transform.rotation);
            enemies = 5;
            AorB = true;
        }
    }

    void EnemyDestroyed() 
    {
        enemies--;
        print(enemies);
    }
}
