using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    public float initialPositionY = -4f;
    public float speed = 0.5f;
    public GameManager gm;
    float paddleChangeSize;
    float leftScreenEdge;
    float rightScreenEdge;

    // Start is called before the first frame update
    void Start()
    {
        paddleChangeSize = this.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }

        if (transform.localScale.x < 0.7f)
        {
            leftScreenEdge = -5.02f - transform.localScale.x; 
            rightScreenEdge = 5.05f + transform.localScale.x;
        }

        if (transform.localScale.x == 0.7f)
        {
            leftScreenEdge = -4.42f - transform.localScale.x; 
            rightScreenEdge = 4.45f + transform.localScale.x;
        }        

        if (transform.localScale.x == 1.2f)
        {
            leftScreenEdge = -3.42f - transform.localScale.x; 
            rightScreenEdge = 3.45f + transform.localScale.x;
        }

        if (transform.localScale.x == 1.7)
        {
            leftScreenEdge = -2.42f - transform.localScale.x; 
            rightScreenEdge = 2.45f + transform.localScale.x;
        }


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
            gm.UpdateLives(1);
            Destroy (other.gameObject);
        }

        if (other.CompareTag("enlarge"))
        {
            if (transform.localScale.x <= 0.4f)
            {
                paddleChangeSize += 0.3f;
                transform.localScale = new Vector2 (paddleChangeSize, 1.5f);
            }

            else if (transform.localScale.x < 1.6f)
            {
                paddleChangeSize += 0.5f;
                transform.localScale = new Vector2 (paddleChangeSize, 1.5f);
            }
            Destroy (other.gameObject);
        }

        if (other.CompareTag("reduce"))
        {
            if (transform.localScale.x == 0.7f)
            {
                paddleChangeSize -= 0.3f;
                transform.localScale = new Vector2 (paddleChangeSize, 1.5f);
            }

            else if (transform.localScale.x > 0.7f)
            {
                paddleChangeSize -= 0.5f;
                transform.localScale = new Vector2 (paddleChangeSize, 1.5f);
            }
            Destroy (other.gameObject);
        }

    }
}
