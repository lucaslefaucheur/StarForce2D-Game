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
        // if user presses space key 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // shoot one bolt at the center of the player's ship 
            Instantiate(shot, new Vector3(shotSpawn.position.x, shotSpawn.position.y+1, shotSpawn.position.z), shotSpawn.rotation);

            // if the player has the first upgrade 
            if (boltLevel == 2) {
                // shoot another bolt in front of the original one  
                Instantiate(shot, new Vector3(shotSpawn.position.x, shotSpawn.position.y+3, shotSpawn.position.z), shotSpawn.rotation);
            }

            // if the player has the second upgrade
            if (boltLevel == 3) {
                // shoot another bolt on the left of the original one 
                Instantiate(shot, new Vector3(shotSpawn.position.x - 1, shotSpawn.position.y, shotSpawn.position.z), shotSpawn.rotation);
                // shoot another bolt on the right of the original one 
                Instantiate(shot, new Vector3(shotSpawn.position.x + 1, shotSpawn.position.y, shotSpawn.position.z), shotSpawn.rotation);
            }
        }
    }

    void FixedUpdate()
    {
        // move the player's ship following the arrow keys 
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        rb.velocity = movement * speed;

        // take care that the player's ship does not exceed the boundaries
        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, xMin, xMax),
                Mathf.Clamp(rb.position.y, yMin, yMax),
                0.0f
            );
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the player's ship is touched by an enemy's ship 
        if (other.tag == "EnemyShip")
        {
            TakeDamage(); // take some damage 
        }

        // if the player's ship is touched by an enemy's bolt
        if (other.tag == "EnemyBolt")
        {
            Destroy(other); // destroy the enemy's bolt
            TakeDamage(); // take some damage 
        }

        // if the payer's ship is touched by its own bolt 
        if (other.tag == "PlayerBolt") 
        {
            Destroy(other); // destroy its bolt 
            TakeDamage(); // take some damage 
        }

        // if the player's ship is touched by a power up
        if (other.tag == "PowerUp")
        {
            Destroy(other); // destroy the power up 
            if (boltLevel < 3) // upgrade the player's bolt level
                boltLevel++;
        }
    }

    void TakeDamage()
    {
        DamageSound.Play(); // play a sound 
        boltLevel--; // reduce the player's bolt level
        Instantiate(PlayerHitParticle, gameObject.transform.position, gameObject.transform.rotation); // emit a particle effect
        if (boltLevel <= 0) // if the player's bolt level is 0
            GameObject.FindGameObjectWithTag("GameController").SendMessage("End"); // notify the game controller
    }
}