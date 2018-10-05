using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour {

    private Rigidbody rb;

    public GameObject PowerUpParticle;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.down * 4; // instantiate the movement of the power up 
        Destroy(gameObject, 7); // destroy the power up after 7 seconds
    }

    void OnTriggerEnter(Collider other)
    {
        // if the power up is touched by a player
        if (other.tag == "Player")
        {
            Instantiate(PowerUpParticle, gameObject.transform.position, gameObject.transform.rotation); // emit a particle effect
            Destroy(gameObject); // destroy the power up 
        }
    }
}
