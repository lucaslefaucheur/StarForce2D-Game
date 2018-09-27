using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAController : MonoBehaviour {

    int direction = 1;

	void Update () 
    {
        if (gameObject.transform.position.y >= 18)
            direction = 1;

        if (gameObject.transform.position.y <= 4)
            direction = -1;

        transform.Translate(0, 0, 2 * direction * Time.deltaTime);
    }
}