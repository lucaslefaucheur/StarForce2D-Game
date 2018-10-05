using System.Collections;
using UnityEngine;

public class EnemyBoltController: MonoBehaviour {

    private void Update()
    {
        transform.Translate(0, 10 * Time.deltaTime, 0); // set the movement of the enemy's fire bolt 
        Destroy(gameObject, 3); // destroy the enemy's bolt after 3 seconds 
    }
}
