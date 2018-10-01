using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float xMin, xMax, yMin, yMax;

    private Rigidbody rb;
    private AudioSource DamageSound; 

    public GameObject shot;
    public Transform shotSpawn;

    public GameObject PlayerHitParticle;

    private int boltLevel;

    private void Start()
    {
        boltLevel = 1;
        rb = GetComponent<Rigidbody>();
        DamageSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(shot, new Vector3(shotSpawn.position.x, shotSpawn.position.y+1, shotSpawn.position.z), shotSpawn.rotation);

            if (boltLevel == 2) {
                Instantiate(shot, new Vector3(shotSpawn.position.x, shotSpawn.position.y+3, shotSpawn.position.z), shotSpawn.rotation);
            }
            if (boltLevel == 3) {
                Instantiate(shot, new Vector3(shotSpawn.position.x - 1, shotSpawn.position.y, shotSpawn.position.z), shotSpawn.rotation);
                Instantiate(shot, new Vector3(shotSpawn.position.x + 1, shotSpawn.position.y, shotSpawn.position.z), shotSpawn.rotation);
            }
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
        if (other.tag == "EnemyShip")
        {
            TakeDamage();
        }
        if (other.tag == "EnemyBolt")
        {
            Destroy(other);
            TakeDamage();
        }
        if (other.tag == "PlayerBolt") 
        {
            TakeDamage();
            Destroy(other);
        }
        if (other.tag == "PowerUp")
        {
            Destroy(other);
            if (boltLevel < 3)
                boltLevel++;
        }
    }

    void TakeDamage()
    {
        DamageSound.Play();
        boltLevel--;
        Instantiate(PlayerHitParticle, gameObject.transform.position, gameObject.transform.rotation);
        if (boltLevel <= 0)
            GameObject.FindGameObjectWithTag("GameController").SendMessage("End");
    }
}