using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public float xMin, xMax, yMin, yMax;

    private Rigidbody rb;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Instantiate(object, position, rotation);
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        rb.velocity = movement * speed;

        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, xMin, xMax),
                Mathf.Clamp(rb.position.y, yMin, yMax),
                0.0f
            );
        rb.rotation = Quaternion.Euler(-90.0f, rb.velocity.x * -tilt, 0.0f); // facultatif (ca rajoute du tilt
    }
}
