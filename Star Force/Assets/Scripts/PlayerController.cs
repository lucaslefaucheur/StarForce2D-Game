using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float xMin, xMax, yMin, yMax;

    private Rigidbody rb;

    public GameObject shot;
    public Transform shotSpawn;

    private int life = 3;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        rb.velocity = movement * speed;

        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, xMin, xMax),
                Mathf.Clamp(rb.position.y, yMin, yMax),
                0.0f
            );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "PlayerBolt")
        {
            Destroy(other);
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        print(life);
        life --;
        if (life <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
