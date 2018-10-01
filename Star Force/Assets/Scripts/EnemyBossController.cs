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
        if (gameObject.transform.position.y >= 16)
            direction = 1;

        if (gameObject.transform.position.y <= 0)
            direction = -1;

        transform.Translate(0, 0, direction * Time.deltaTime);

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
        if (other.tag == "PlayerBolt")
        {
            DamageSound.Play();
            Instantiate(EnemyHitParticle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(other.gameObject);
            GameObject.FindGameObjectWithTag("GameController").SendMessage("BossTakeDamage");
        }
    }
}
