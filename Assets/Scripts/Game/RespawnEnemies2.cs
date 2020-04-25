using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemies2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public static float respawnTime = RespawnEnemies.respawnTime;
    private Vector2 ScreenBounds;
    public static bool play;

    void Start()
    {
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(callEnemies());
    }

    private void spawnEnemy()
    {
        GameObject createEnemyInScene = Instantiate(enemyPrefab) as GameObject;
        SpriteRenderer renderer = createEnemyInScene.GetComponent<SpriteRenderer>();
        createEnemyInScene.transform.position = new Vector2(Random.Range(-ScreenBounds.x, ScreenBounds.x - 0.5f) + 0.5f, ScreenBounds.y + Random.Range(0,3));
        if(play)
        {
            renderer.color = new Color(100f,81f,0.1f);
            createEnemyInScene.tag = "HexagonPlusEight";
            createEnemyInScene.GetComponent<ParticleSystem>().Play();
        }
        else {
            createEnemyInScene.GetComponent<ParticleSystem>().Stop();
        }
    }

    IEnumerator callEnemies() {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
