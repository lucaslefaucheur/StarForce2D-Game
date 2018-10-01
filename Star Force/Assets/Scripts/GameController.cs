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
        SpawnWave();
        EnemyA = true;
        Boss = false;
    }

    private void Update()
    {
        if (enemies <= 0)
        {
            if (multiplier < 16)
            {
                SpawnPowerUp();
                SpawnWave();
                multiplier *= 2;
            } 
            else if (!Boss)
            {
                SpawnBoss();
            }
        }
    }

    void SpawnPowerUp () 
    {
        Instantiate(PowerUp, new Vector3(Random.Range(-8, 8), 19, 0), PowerUp.transform.rotation);
    }

    void SpawnWave () 
    {
        if (EnemyA) 
        {
            Instantiate(EnemyShipA, new Vector3(-8, 23, 0), EnemyShipA.transform.rotation);
            Instantiate(EnemyShipA, new Vector3(-4, 21, 0), EnemyShipA.transform.rotation);
            Instantiate(EnemyShipA, new Vector3(0, 19, 0), EnemyShipA.transform.rotation);
            Instantiate(EnemyShipA, new Vector3(4, 21, 0), EnemyShipA.transform.rotation);
            Instantiate(EnemyShipA, new Vector3(8, 23, 0), EnemyShipA.transform.rotation);
            enemies = 5;
            EnemyA = false;
        }
        else 
        {
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
        Instantiate(EnemyShipBoss, new Vector3(0, 19, 0), EnemyShipBoss.transform.rotation);
        Boss = true;
    }

    void EnemyTakeDamage(int n) 
    {
        score += (n * multiplier);
        ScoreText.text = score.ToString();
        enemies--;
    }

    void BossTakeDamage()
    {
        score += (300 * multiplier);
        ScoreText.text = score.ToString();
        boss--;
        BossLifeText.text = boss.ToString();
        if (boss <= 0)
            End();
    }

    void End() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}