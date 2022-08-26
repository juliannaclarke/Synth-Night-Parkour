using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController player = null;

    public float jumpForce;
    bool jump = false;

    Vector3 angularVelocity = new Vector3(0, 100, 0);
    float halfScale = 2.0f;
    float fullScale = 4.0f;

    bool isGrounded = false;
    bool onPlatform = false;

    float maxSpeed = 11.0f;
    public static float speed = 5f;

    float timer = 0f;

    //public float doubleTapSpeed;
    //float lastClicked;


    void Start()
    {
        if (player == null)
        {
            player = this;
        }

    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKey(KeyCode.X))
        {
            transform.localScale = new Vector3(1.0f, halfScale, 1.0f);
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            //if they are on a platform, cool jump
            transform.localScale = new Vector3(1.0f, fullScale, 1.0f);

            if (isGrounded || onPlatform)
            {
                jump = true;
            }

        }

        if ((timer > 30) && speed < maxSpeed)
        {
            speed+=1;
            Debug.Log(speed);
            timer = 0f;
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (jump)
        {
            rb.AddForce(jumpForce * transform.up);
            if (onPlatform)
            {
                StartCoroutine(Rotate(0.5f));
            }

            jump = false;
            isGrounded = false;
            onPlatform = false;
        }
    }

    IEnumerator Rotate(float duration)
    {
        float startRotation = transform.eulerAngles.y;
        float endRotation = startRotation + 360.0f;
        float rotateTime = 0.0f;

        while (rotateTime < duration)
        {
            rotateTime += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, rotateTime / duration) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EdgeCollider2D wallEdge = collision.gameObject.GetComponent<EdgeCollider2D>();

        if (collision == wallEdge)
        {
            StateManager.i.setGameState(gameState.GAME_OVER);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            onPlatform = true;
        }
        else if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            onPlatform = false;
        }
    }
}
