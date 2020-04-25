using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lives : MonoBehaviour
{
    // Start is called before the first frame update
    public static int lives;
    public Text lifeLevel;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifeLevel.text = "Lives: " + lives;
    }
}
