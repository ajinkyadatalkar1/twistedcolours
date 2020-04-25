using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScore : MonoBehaviour
{
    // Start is called before the first frame update
    public static int highScore;
    public Text high;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Score.scoreValue > highScore) {
            highScore = Score.scoreValue;
            PlayerPrefs.SetInt("highscore",highScore);
        }
        high.text = "High Score:" + highScore;
    }
}
