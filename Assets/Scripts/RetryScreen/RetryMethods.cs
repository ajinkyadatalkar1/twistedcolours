using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryMethods : MonoBehaviour
{
    public void respawn() {
        SceneManager.LoadScene("Game");
    }

    public void home() {
        SceneManager.LoadScene("StartScreen");
        //Score.scoreValue = 0;
    }
}
