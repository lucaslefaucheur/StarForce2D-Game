using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+ 1);
    }

    public void BulletHellMode() {
        //GameObject.FindGameObjectWithTag("PlayerBolt").SendMessage("BulletHellMode");
    }
}
