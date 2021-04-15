using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score;
    public int lives;
    public Text scoreText;
    public Text livesText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public int numberOfBricks;
    public Transform[] levels;
    public int currentLevelIndex = 0;
    public Ball ball;
    public Paddle paddle;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;   
        numberOfBricks = GameObject.FindGameObjectsWithTag ("brick").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfBricks <= 0)
        {
            Destroy (GameObject.Find ("ExtraLife(Clone)"));   
            Destroy (GameObject.Find ("Enlarge(Clone)"));
            Destroy (GameObject.Find ("Reduce(Clone)"));
        }
    }

    public void UpdateLives (int changeInLives)
    {
        lives += changeInLives;

        if (lives <=0)
        {
            lives = 0;
            GameOver();
        }

        livesText.text = "Lives: " + lives;
    }

    public void UpdateScore (int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;

        if (numberOfBricks <= 0)
        {
            if (currentLevelIndex >= levels.Length - 1)
            {
                GameOver();
            }
            else
            {
                gameOver = true;
            }
        }
    }

    public void LoadLevel ()
    {
        currentLevelIndex++;
        Instantiate (levels [currentLevelIndex], Vector2.zero, Quaternion.identity);
        paddle.transform.localScale = new Vector2 (0.7f, 1.5f); 
        numberOfBricks = GameObject.FindGameObjectsWithTag ("brick").Length;
        ball.extraLifeLimit = false;
        gameOver = false;
    }

    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive (true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene ("Arkanoid"); 
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log ("Game Quit");
    }


}
