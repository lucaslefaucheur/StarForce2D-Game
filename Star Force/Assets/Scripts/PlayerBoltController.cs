using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoltController : MonoBehaviour {

    public bool BulletHell;
    private int count = 1;

    private void Update()
    {
        transform.Translate(0, -20 * Time.deltaTime, 0);
        if (BulletHell) 
        {
            if (gameObject.transform.position.y >= 20) 
            {
                if (count < 3)
                {
                    float posx = gameObject.transform.position.x;
                    transform.position += new Vector3(-2 * posx, -30, 0);
                    count++;
                }
                else 
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
