using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour {

    private Rigidbody rb;

    public GameObject PowerUpParticle;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.down * 4;
        Destroy(gameObject, 7);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(PowerUpParticle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
