using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void LoadGameScene() {
        if(Lives.lives > 0) {
        SceneManager.LoadScene("Game");
        Score.scoreValue = 0;
        } else {
        
        }
    }

    public void ExitGame() {
        Application.Quit();
    }
}
