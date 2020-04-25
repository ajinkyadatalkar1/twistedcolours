using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeBackground : MonoBehaviour
{
    // Start is called before the first frame update
        public float minimum = 0.0f;
        public float maximum = 1f;
        public float duration = 5.0f;
        private float startTime;
    public SpriteRenderer sprite;    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = (Time.time - startTime) / duration;
        sprite.color = new Color(1f,1f,1f,Mathf.SmoothStep(minimum, maximum, t));
    }
}
