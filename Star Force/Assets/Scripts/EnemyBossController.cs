using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBossController : MonoBehaviour {

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

    void Update()
    {
        // determine the y direction of the enemy ship 
        if (gameObject.transform.position.y >= 16)
            direction = 1;
        if (gameObject.transform.position.y <= 0)
            direction = -1;

        // move the enemy ship continuously in the direction determined above
        transform.Translate(0, 0, direction * Time.deltaTime);

        // enemy ship shoots 3 bolt regularly 
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            Instantiate(shot, new Vector3(shotSpawn.position.x - 1, shotSpawn.position.y + 1, shotSpawn.position.z), shotSpawn.rotation);
            Instantiate(shot, new Vector3(shotSpawn.position.x + 1, shotSpawn.position.y + 1, shotSpawn.position.z), shotSpawn.rotation);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // if the boss enemy ship is touched by a player's bolt 
        if (other.tag == "PlayerBolt")
        {
            DamageSound.Play(); // play a sound (does not work)
            Instantiate(EnemyHitParticle, gameObject.transform.position, gameObject.transform.rotation); // emit a particle effect
            Destroy(other.gameObject); // destroy the player's bolt
            GameObject.FindGameObjectWithTag("GameController").SendMessage("BossTakeDamage"); // notify the game controller
        }
    }
}
