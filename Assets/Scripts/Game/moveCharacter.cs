using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    private float speed = 10.0f;
    private Vector2 ScreenBounds;
    private Vector2 PointA; // for mouse and touch screen (Point when button was pressed or screen was touched)
    private Vector2 PointB; // for mouse and touch screen (Point when button was released or finger was lifted of the screen)
    private bool touchStart = false;
    private float playerYposition;

    public Transform circle;
    public Transform outerCircle;
    Vector2 offset;
    Vector2 direction;
    void Start()
    {
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        move(new Vector2(Mathf.Clamp(Input.GetAxis("Horizontal"),-2,2), Input.GetAxis("Vertical")));
        if(Input.GetMouseButtonDown(0)) {
            touchStart = false;
            PointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, Camera.main.transform.position.z));
            circle.transform.position = PointA;
            outerCircle.transform.position = PointA;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        } 
        if(Input.GetMouseButton(0)){
            touchStart = true;
            PointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else {
            touchStart = false;
        }
    }

   private void FixedUpdate() {
        if(touchStart) {
            offset = PointB - PointA;
            if(Mathf.Abs(offset.x) >= 0.01f || Mathf.Abs(offset.y) >= 0.01f){
            direction = Vector2.ClampMagnitude(offset, 1.0f);
            move(direction);
            circle.transform.position = new Vector2(PointA.x + direction.x, PointA.y + direction.y);
            }
        }
        else {
            /*circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;*/
        }
    }

    public void move(Vector2 direction) {
        player.Translate(direction * speed * Time.deltaTime);
    }
}
