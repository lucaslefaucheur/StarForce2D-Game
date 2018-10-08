using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject EnemyShipA;
    public GameObject EnemyShipB;
    public GameObject EnemyShipBoss;
    public GameObject PowerUp;

    private int enemies;
    private int boss;
    bool EnemyA;
    bool Boss;

    public Text ScoreText;
    public Text BossLifeText;

    private int score;
    private int multiplier;

    private void Start()
    {
        enemies = 0;
        boss = 10;
        score = 0;
        multiplier = 1;
        ScoreText.text = score.ToString();
        EnemyA = true;
        SpawnWave(); 
        Boss = false;
    }

    private void Update()
    {
        // if a wave is over 
        if (enemies <= 0)
        {
            if (multiplier < 16)
            {
                SpawnPowerUp(); // spawn a power up 
                SpawnWave(); // spawn another enemy wave 
                multiplier *= 2; // increase the multiplier 
            } 
            else if (!Boss)
            {
                SpawnBoss(); // spawn the final boss
            }
        }
    }

    void SpawnPowerUp () 
    {
        // spawn a power up at a random x postion 
        Instantiate(PowerUp, new Vector3(Random.Range(-8, 8), 19, 0), PowerUp.transform.rotation);
    }

    void SpawnWave () 
    {
        if (EnemyA) // if the previous wave was ships of type B
        {
            // spawn 5 ships of type A
            Instantiate(EnemyShipA, new Vector3(-8, 23, 0), EnemyShipA.transform.rotation);
            Instantiate(EnemyShipA, new Vector3(-4, 21, 0), EnemyShipA.transform.rotation);
            Instantiate(EnemyShipA, new Vector3(0, 19, 0), EnemyShipA.transform.rotation);
            Instantiate(EnemyShipA, new Vector3(4, 21, 0), EnemyShipA.transform.rotation);
            Instantiate(EnemyShipA, new Vector3(8, 23, 0), EnemyShipA.transform.rotation);
            enemies = 5;
            EnemyA = false;
        }
        else  // if the previous wave was ships of type A
        {
            // spawn 5 ships of type B
            Instantiate(EnemyShipB, new Vector3(-8, 19, 0), EnemyShipB.transform.rotation);
            Instantiate(EnemyShipB, new Vector3(-4, 21, 0), EnemyShipB.transform.rotation);
            Instantiate(EnemyShipB, new Vector3(0, 23, 0), EnemyShipB.transform.rotation);
            Instantiate(EnemyShipB, new Vector3(4, 25, 0), EnemyShipB.transform.rotation);
            Instantiate(EnemyShipB, new Vector3(8, 27, 0), EnemyShipB.transform.rotation);
            enemies = 5;
            EnemyA = true;
        }
    }

    void SpawnBoss () 
    {
        // spawn the final boss 
        Instantiate(EnemyShipBoss, new Vector3(0, 19, 0), EnemyShipBoss.transform.rotation);
        Boss = true;
    }

    void EnemyTakeDamage(int n) 
    {
        score += (n * multiplier); // update the score 
        ScoreText.text = score.ToString();
        enemies--; // reduce the number of enemies 
    }

    void BossTakeDamage()
    {
        score += (300 * multiplier); // update the score 
        ScoreText.text = score.ToString();
        boss--; // reduce the number of lifes of the boss
        BossLifeText.text = boss.ToString();
        if (boss <= 0) // if the number of lifes of the boss is 0
            End(); // end the game 
    }

    void End() 
    {
        // load the menu scene 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}