using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoltController : MonoBehaviour {

    public bool BulletHell;
    private int count = 1;

    public void setNormal() { BulletHell = false; } // accessed by the menu to set the mode to normal
    public void setBulletHell() { BulletHell = true; } // accessed by the menu to set the mode to bullet hell

    private void Update()
    {
        transform.Translate(0, -20 * Time.deltaTime, 0); // set the movement of the player's bolt 

        // if the mode is set to bullet hell
        if (BulletHell) 
        {
            // if the bolt reaches the top of the screen 
            if (gameObject.transform.position.y >= 20) 
            {
                // if the bolt has not already traversed the screen 3 times 
                if (count < 3)
                {
                    float posx = gameObject.transform.position.x;
                    transform.position += new Vector3(-2 * posx, -22, 0); // set the player's bolt back to the bottom of the screen and at -x
                    count++;
                }
                else 
                {
                    Destroy(gameObject); // destroy the player's bolt 
                }
            }
        }

        Destroy(gameObject, 9); // destroy the player's bolt after 3 seconds 
    }


}
