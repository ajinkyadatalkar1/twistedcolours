using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D coinRigidBody;
    private Vector2 ScreenBounds;
    void Start()
    {
        coinRigidBody = this.GetComponent<Rigidbody2D>();
        coinRigidBody.velocity = new Vector2(0, -7);
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < ScreenBounds.y * -2){
            Destroy(this.gameObject);
            // Score.scoreValue += 2;
        }
    }
}
