﻿using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour {

    private Rigidbody rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * speed;
    }
}
