using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    public float initialPositionY = -4f;
    public float speed = 0.5f;
    public GameManager gm;
    public SpriteRenderer sr;
    public float defaultPaddleWidthInPixels = 200f;
    float paddleShift;
    float leftScreenEdge;
    float rightScreenEdge;
    public Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }

        if (this.sr.size.x == 1)
        {
            paddleShift = this.sr.size.x / 2f;
            leftScreenEdge = -4.82f - paddleShift; 
            rightScreenEdge = 4.88f + paddleShift;
        }        

        if (this.sr.size.x == 2)
        {
            paddleShift = this.sr.size.x / 2f;
            leftScreenEdge = -3.82f - paddleShift; 
            rightScreenEdge = 3.88f + paddleShift;
        }

        if (this.sr.size.x == 3)
        {
            paddleShift = this.sr.size.x / 2f;
            leftScreenEdge = -2.82f - paddleShift; 
            rightScreenEdge = 2.88f + paddleShift;
        }
        
        if (this.sr.size.x == 4)
        {
            paddleShift = this.sr.size.x / 2f;
            leftScreenEdge = -1.82f - paddleShift; 
            rightScreenEdge = 1.88f + paddleShift;
        }

        col.size = new Vector2 (this.sr.size.x, 0.05f);

        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);   
        transform.position = new Vector2 (cursorPosition.x, initialPositionY);
    
        if (transform.position.x < leftScreenEdge)
        {
            transform.position = new Vector2 (leftScreenEdge, initialPositionY);
        }
        if (transform.position.x > rightScreenEdge)
        {
            transform.position = new Vector2 (rightScreenEdge, initialPositionY);
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("extraLife"))
        {
            if (other.CompareTag("extraLife"))
            {
                gm.UpdateLives(1);
                Destroy (other.gameObject);
            }
        }
    }
}
