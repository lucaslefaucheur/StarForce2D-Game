using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBController : MonoBehaviour {

    int direction = 1;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    void Update()
    {
        if (gameObject.transform.position.y >= 18)
            direction = 1;

        if (gameObject.transform.position.y <= 4)
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
            Destroy(other.gameObject);
            Destroy(gameObject);
            var test = GameObject.FindGameObjectWithTag("GameController");
            test.SendMessage("EnemyDestroyed");
        }
    }
}
