using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class awakePrefs : MonoBehaviour
{
    private int highscore;
    private int lives;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("highscore")){
            HighScore.highScore = PlayerPrefs.GetInt("highscore");
        } else {
            HighScore.highScore = 0;
        }

        if(PlayerPrefs.HasKey("lives")) {
            Lives.lives = PlayerPrefs.GetInt("lives");
        } else {
            Lives.lives = 700;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
