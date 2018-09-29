using System.Collections;
using UnityEngine;

public class EnemyBoltController: MonoBehaviour {

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.down * 10;
        Destroy(gameObject, 3);
    }
}
