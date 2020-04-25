using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipCollision : MonoBehaviour
{
private bool coroutineStatus = true;
public GameObject explosion;
public GameObject plusOne;
public GameObject plusEight;
public GameObject plusTwelve;
private void OnTriggerEnter2D(Collider2D other) {
  if(other.tag == "enemyBlue" || other.tag == "enemyGreen") {
      StartCoroutine(LoadStartScreen());
      GameObject showExplosion = Instantiate(explosion) as GameObject;
      showExplosion.transform.position = transform.position;
      Destroy(other.gameObject);
      //Application.LoadLevel(Application.loadedLevel); // This how you restart a scene. Keep for record.
      if(Lives.lives > 0) {
        Lives.lives -= 1;
        PlayerPrefs.SetInt("lives", Lives.lives);
      }
  }

  else if(other.tag == "HexagonPlusEight") {
    GameObject showPlusEight = Instantiate(plusEight) as GameObject;
    showPlusEight.transform.position = transform.position;
    Score.scoreValue +=8;
    Destroy(other.gameObject);
    Destroy(showPlusEight, 0.5f);
  }

  else if(other.tag == "starPlus12") {
    GameObject showPlusTwelve = Instantiate(plusTwelve) as GameObject;
    showPlusTwelve.transform.position = transform.position;
    Score.scoreValue +=12;
    Destroy(other.gameObject);
    Destroy(showPlusTwelve, 0.5f);
  }

  else if(other.tag == "goldCoin") {
    GameObject showPlusOne = Instantiate(plusOne) as GameObject;
    showPlusOne.transform.position = transform.position;
    Score.scoreValue +=1;
    Destroy(other.gameObject);
    Destroy(showPlusOne, 0.5f);
  }
  else{
    Debug.Log("collided with:" + other.tag);
  }
}

IEnumerator LoadStartScreen(){
  if(coroutineStatus){
  yield return new WaitForSeconds(0.5f);
  LoadStartScene();
  this.gameObject.SetActive(false);
  }
}

private void LoadStartScene() {
  SceneManager.LoadScene("RetryScreen");
  coroutineStatus = false;
}
}
