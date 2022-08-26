using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(transform.position.x - (PlayerController.speed * Time.deltaTime), transform.position.y, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "boundary")
        {
            Destroy(gameObject);
        }
    }
}
