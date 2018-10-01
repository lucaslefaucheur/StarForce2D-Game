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
        if (gameObject.transform.position.y >= 16)
            direction = 1;

        if (gameObject.transform.position.y <= 0)
            direction = -1;

        transform.Translate(0, 0, 2 * direction * Time.deltaTime);

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBolt")
        {
            DamageSound.Play();
            Instantiate(EnemyHitParticle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("GameController").SendMessage("EnemyTakeDamage", 100);
        }
    }
}