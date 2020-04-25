using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed;
    private Rigidbody2D enemyRigidBody;
    private Vector2 ScreenBounds;
    void Start()
    {
        rotationSpeed = Random.Range(3,9) * 15;
        enemyRigidBody = this.GetComponent<Rigidbody2D>();
        enemyRigidBody.velocity = new Vector2(0, -9);
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, rotationSpeed * Time.deltaTime);
        if(transform.position.y < ScreenBounds.y * -2){
            Destroy(this.gameObject);
            Score.scoreValue += 2; 
        }
    }
}
