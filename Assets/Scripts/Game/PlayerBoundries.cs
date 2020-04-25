using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundries : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 ScreenBounds;
    private float objectWidth;
    private float objectHeight;
    void Start()
    {
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, ScreenBounds.x * -1 + objectWidth/2, ScreenBounds.x - objectWidth/2);
        viewPos.y = Mathf.Clamp(viewPos.y, ScreenBounds.y * -1 + objectHeight/2, ScreenBounds.y - objectHeight/2);
        transform.position = viewPos;
    }
}
