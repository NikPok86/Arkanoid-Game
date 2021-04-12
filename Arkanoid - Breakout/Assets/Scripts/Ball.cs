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
    public Transform powerup;
    public GameManager gm;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }
        
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
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives (-1);    
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
            int randChance = Random.Range(1, 101);
            if (randChance % 33 == 0)
            {
                Instantiate (powerup, other.transform.position, other.transform.rotation);
            }

            Transform newExplosion = Instantiate (explosion, other.transform.position, other.transform.rotation);
            Destroy (newExplosion.gameObject, 1f);

            gm.UpdateScore (other.gameObject.GetComponent<Brick>().points);
            gm.UpdateNumberOfBricks();
            Destroy (other.gameObject);
        }   

        if (other.gameObject.CompareTag("paddle") && transform.position.y >= -3.80)
        {
            float x = hitFactor (transform.position, other.transform.position, other.collider.bounds.size.x);
            Vector2 dir = new Vector2 (x, 0.25f).normalized;
            GetComponent<Rigidbody2D>().velocity = (dir) * speed * Time.deltaTime;
        }
    }
}
