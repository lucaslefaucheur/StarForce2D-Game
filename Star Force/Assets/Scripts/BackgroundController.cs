using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	void Update () {
        // move the background image down -> to give the illusion that we are moving up 
        transform.Translate(0, -Time.deltaTime, 0);

        // reposition the background image on top of the other -> to give the illusion of inifite background
        if (transform.position.y <= -12)
        {
            transform.position += new Vector3(0, 40, 0);
        }
    }
}
