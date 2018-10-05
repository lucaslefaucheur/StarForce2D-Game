using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBController : MonoBehaviour {

    int directionx = -1;
    int directiony = 1;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    public GameObject EnemyHitParticle;

    private AudioSource DamageSound;

    private void Start()
    {
        DamageSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        // determine the x direction of the enemy ship 
        if (gameObject.transform.position.x <= -8)
            directionx = 1;
        if (gameObject.transform.position.x >= 8)
            directionx = -1;

        // determine the y direction of the enemy ship 
        if (gameObject.transform.position.y >= 16)
            directiony = 1;
        if (gameObject.transform.position.y <= 0)
            directiony = -1;

        // move the enemy ship continuously in the direction determined above
        transform.Translate(2 * directionx * Time.deltaTime, 0, 2 * directiony * Time.deltaTime);

        // enemy ship shoots a bolt regularly 
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // if an enemy ship is touched by a player's bolt 
        if (other.tag == "PlayerBolt")
        {
            DamageSound.Play(); // play a sound (does not work)
            Instantiate(EnemyHitParticle, gameObject.transform.position, gameObject.transform.rotation); // emit a particle effect
            Destroy(other.gameObject); // destroy the player's bolt
            Destroy(gameObject); // destroy the enemy ship 
            GameObject.FindGameObjectWithTag("GameController").SendMessage("EnemyTakeDamage", 200); // notify the game controller
        }
    }
}
