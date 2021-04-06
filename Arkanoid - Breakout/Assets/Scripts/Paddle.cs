using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    public float initialPositionY = -4f;
    public float speed = 0.5f;
    public float rightScreenEdge = 4.88f;
    public float leftScreenEdge = -4.82f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
