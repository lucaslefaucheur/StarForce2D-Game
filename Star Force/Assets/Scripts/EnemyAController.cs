using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAController : MonoBehaviour {

    int direction = 1;

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

    void Update () 
    {
        // determine the y direction of the enemy ship 
        if (gameObject.transform.position.y >= 16)
            direction = 1;
        if (gameObject.transform.position.y <= 0)
            direction = -1;

        // move the enemy ship continuously in the direction determined above
        transform.Translate(0, 0, 4 * direction * Time.deltaTime);

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
            GameObject.FindGameObjectWithTag("GameController").SendMessage("EnemyTakeDamage", 100); // notify the game controller
        }
    }
}