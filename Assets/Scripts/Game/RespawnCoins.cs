using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCoins : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject coin;
    public GameObject starPlus12;
    private float respanCoins = 5.0f;
    private float xAxis;
    private float yAxis;
    private Vector2 ScreenBounds;

    private int callStar=0;

    void Start()
    {
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(generateCoins());
    }

    // Update is called once per frame
    private void respawnCoins()
    {
        xAxis = Random.Range(-ScreenBounds.x, ScreenBounds.x);
        yAxis = ScreenBounds.y;
        int i=0;
        for(i=0; i<=Random.Range(0,10);i++){
            GameObject Coinclone = Instantiate(coin) as GameObject;
            Coinclone.transform.position = new Vector2(xAxis, ScreenBounds.y + i * 1.4f);
        }
        if(callStar == 5){
            GameObject showStar = Instantiate(starPlus12) as GameObject;
            showStar.transform.position = new Vector2(xAxis, ScreenBounds.y + i * 1.4f);
            callStar = 0;
        }
        callStar++;
    }

    IEnumerator generateCoins() {
        while(true){
        yield return new WaitForSeconds(respanCoins);
        respawnCoins();
        }
    }
}
