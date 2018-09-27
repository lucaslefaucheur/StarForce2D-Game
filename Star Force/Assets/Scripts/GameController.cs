using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject EnemyShipA;
    public GameObject EnemyShipB;

    private void Start()
    {
        SpawnWaves();
    }

    void SpawnWaves () 
    {
        Instantiate(EnemyShipA, new Vector3(-8, 23, 0), EnemyShipA.transform.rotation);
        Instantiate(EnemyShipA, new Vector3(-4, 21, 0), EnemyShipA.transform.rotation);
        Instantiate(EnemyShipA, new Vector3(0, 19, 0), EnemyShipA.transform.rotation);
        Instantiate(EnemyShipA, new Vector3(4, 21, 0), EnemyShipA.transform.rotation);
        Instantiate(EnemyShipA, new Vector3(8, 23, 0), EnemyShipA.transform.rotation);
    }
}
