using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	void Update () {
        transform.Translate(0, -Time.deltaTime, 0);
        if (transform.position.y <= -12)
        {
            transform.position += new Vector3(0, 40, 0);
        }
    }
}
