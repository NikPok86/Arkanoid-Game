using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform explosion;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!inPlay)
        {
            transform.position = paddle.position;
        }

        if (Input.GetMouseButtonDown(0) && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bottom"))
        {
            Debug.Log("Ball fell");
            rb.velocity = Vector2.zero;
            inPlay = false;
        }
    }

    float hitFactor (Vector2 ballPos, Vector2 paddlePos, float paddleWidth)
    {
        return (ballPos.x - paddlePos.x) / paddleWidth;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("brick"))
        {
            Transform newExplosion = Instantiate (explosion, other.transform.position, other.transform.rotation);
            Destroy (newExplosion.gameObject, 1f);
            Destroy (other.gameObject);
        }   

        if (other.gameObject.CompareTag("paddle"))
        {
            float x = hitFactor (transform.position, other.transform.position, other.collider.bounds.size.x);
            Vector2 dir = new Vector2 (x, 0.25f).normalized;
            GetComponent<Rigidbody2D>().velocity = (dir) * speed * Time.deltaTime;
        }
    }
}
