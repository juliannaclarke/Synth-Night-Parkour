using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * (PlayerController.speed / 4f)* Time.deltaTime);
        if (transform.position.x < -14.08f)
        {
            transform.position = startPosition;
        }
    }
}
