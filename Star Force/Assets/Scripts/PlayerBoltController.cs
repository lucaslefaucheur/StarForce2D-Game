using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoltController : MonoBehaviour {

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * 20;
        Destroy(gameObject, 3);
    }
}
