using System.Collections;
using UnityEngine;

public class EnemyBoltController: MonoBehaviour {

    private void Update()
    {
        transform.Translate(0, 10 * Time.deltaTime, 0);
        Destroy(gameObject, 3);
    }
}
