using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Crab : MonoBehaviour
{
    public Text scoreDisplay;

    private Rigidbody2D rb;
    private float speed = 4;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Physics engine will not turn Crab
        rb.freezeRotation = true;
        // no gravity
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            // walk
            float angleRadians = rb.rotation * Mathf.PI / 180f;
            float xSpeed = Mathf.Cos(angleRadians) * speed;
            float ySpeed = Mathf.Sin(angleRadians) * speed;
            rb.velocity = new Vector2(xSpeed, ySpeed);

            if (Input.GetKey(KeyCode.A))
            {
                // and turn left
                rb.rotation += 1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                // and turn right
                rb.rotation -= 1;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Worm"))
        {
            // remove worm
            Destroy(collision.gameObject);

            // score
            score = score + 1;
            scoreDisplay.text = "Score: " + score;
        }
    }
}
