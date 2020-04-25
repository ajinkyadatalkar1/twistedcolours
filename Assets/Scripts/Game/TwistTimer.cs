using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TwistTimer : MonoBehaviour
{
    // Start is called before the first frame update
    private float twistTime = 10f;
    private string[] dodge = {"enemyBlue","enemyGreen","both"};
    private int selector;
    public Image enemyBlue;
    public Image enemyGreen;
    public Text plusEightIndicator;
    void Start()
    {
        StartCoroutine(twist());
        enemyGreen.enabled = true;
        enemyBlue.enabled = true;
        RespawnEnemies.play = false;
        RespawnEnemies2.play = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator twist() {
        while(true)
        {
            yield return new WaitForSeconds(twistTime);
            selector = Random.Range(0,3);
            if(dodge[selector] == "enemyBlue"){
                enemyBlue.enabled = true;
                enemyGreen.enabled = false;
                // plusEightIndicator.text = " (Collect Green for +8)";
                RespawnEnemies.play = true;
                RespawnEnemies2.play = false;
            }
            else if(dodge[selector] == "enemyGreen") {
                enemyGreen.enabled = true;
                enemyBlue.enabled = false;
                RespawnEnemies.play = false;
                RespawnEnemies2.play = true;
                // plusEightIndicator.text = " (Collect Blue for +8)";
            }
            else if(dodge[selector] == "both"){
                enemyGreen.enabled = true;
                enemyBlue.enabled = true;
                RespawnEnemies.play = false;
                RespawnEnemies2.play = false;
                plusEightIndicator.text = "";
            }
            else{
                enemyGreen.enabled = false;
                enemyBlue.enabled = false;
            }
        }
    }
}
